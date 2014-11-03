using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Monads;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using uHelper.Extensions;
using uHelper.Extensions.Excepitons;
using uHelper.webAPI.Domains;
using HtmlAgilityPack;

namespace uHelper.webAPI.Rutracker
{
    public class RutrackerInfoProvider : BaseTrackerInfoProvider
    {
        private readonly CookiesWebClient Client;
        private readonly ISettingsProvider SettingsProvider;

        private const string MAIN_FORUM_URL = "http://rutracker.org/forum";
        private const string LOGIN_FORM_URL = "http://login.rutracker.org/forum/login.php";

        private const int SIZE_AND_DOWNLOADS_ROW_NUMBER = 1;
        private const int SEEDS_AND_LEECHES_ROW_NUMBER = 2;

        public RutrackerInfoProvider(ISettingsProvider settingsProvider)
        {
            SettingsProvider = settingsProvider;
            Client = new CookiesWebClient(GetCookies, new NetworkCredential(SettingsProvider.Username, SettingsProvider.Password));
        }

        public override TopicInfo GetTopicInfo(string topicUrl)
        {
            var content = GetPageContent(topicUrl);
            content = content.Replace("<wbr>", "");
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            
            var title = doc.DocumentNode.SelectSingleNode("//h1[@class='maintitle']").ToText();

            var forum = doc.DocumentNode.SelectSingleNode("//td[@class='nav']").ToText();
            var uploader = doc.DocumentNode.SelectSingleNode("//p[@class='nick nick-author']").ToText(distinct: true);

            var data = doc.DocumentNode.SelectSingleNode("//table[@class='forumline dl_list']").ToTable2();
            
            //Размер:  18.57 GB   |   Зарегистрирован:  3 года 6 месяцев   |   .torrent скачан:  11701 раз
            var sizeAndDownloads = data[SIZE_AND_DOWNLOADS_ROW_NUMBER].Texts.WhereKeyContains("td1");
            var sizeText = sizeAndDownloads.Substring("Размер:", "|", false).Trim();
            var downloadsCount = int.Parse(sizeAndDownloads.Substring(".torrent скачан:  ", " ", false), CultureInfo.InvariantCulture);
            
            //Сиды:  67  [  1 MB/s  ] Личи:  21  [  189 KB/s  ] Подробная статистика пиров
            var seeds = int.Parse(data[SEEDS_AND_LEECHES_ROW_NUMBER].Texts.WhereKeyContains("seed").With(x => x.Substring("Сиды:", "[", false).Trim()).CheckNullWithDefault("0") );
            var leeches = int.Parse(data[SEEDS_AND_LEECHES_ROW_NUMBER].Texts.WhereKeyContains("leech").With(x => x.Substring("Личи:", "[", false).Trim()).CheckNullWithDefault("0"));

            var statusText = doc.DocumentNode.SelectSingleNode("//span[contains(concat(' ',@class,' '),'tor-icon')]").InnerText.RefineHtml();
            
            var link = doc.DocumentNode.SelectSingleNode("//a[@class='dl-stub dl-link']").ToLink();

            return new TopicInfo
            {
                Url = topicUrl,
                Name = title,
                Status = statusText.GetStatus(),
                TorrentLink = link,
                
                SizeTGMKB = sizeText,
                Size = sizeText.GetSizeInBytes(),

                Uploader = uploader,
                Forum = forum,
                
                SeedsCount = seeds,
                LeechesCount = leeches,
                DownloadsCount = downloadsCount
            };
        }
        public override ForumInfo GetForumInfo(string forumUrl)
        {
            var topics = new List<TopicInfo>();
                var start = 0;
            while (true)
            {
                var content = GetPageContent(forumUrl + "&start=" + start);
                content = content.Replace("<wbr>", "");
                var doc = new HtmlDocument();
                doc.LoadHtml(content);

                if (doc.DocumentNode.SelectSingleNode("//table[@class='forumline message']") != null)
                    break;

                var forum = doc.DocumentNode.SelectSingleNode("//td[contains(concat(' ',@class,' '),'nav')]").ToText();
                var table = doc.DocumentNode.SelectSingleNode("//table[@class='forumline forum']").ToTable2().
                                Where(x => x.Links.Any()).ToList();
                try
                {
                    topics.AddRange(table.Select(r => new TopicInfo
                        {
                            Url = r.Links.WhereKeyContains("torTopic").With(url => MAIN_FORUM_URL + url.Remove(0,1)).CheckNullWithDefault("NOT REGISTERED"),
                            Name = r.Texts.WhereKeyContains("torTopic").With(n => n.Remove(0,2)).CheckNullWithDefault("NOT REGISTERED"),
                            Status = r.Texts.WhereKeyContains("tor-icon").With(x => x.GetStatus()),
                            TorrentLink = r.Links.WhereKeyContains("f-dl"),

                            SizeTGMKB = r.Texts.WhereKeyContains("small"),
                            Size = r.Texts.WhereKeyContains("small").GetSizeInBytes(),

                            Uploader = r.Texts.WhereKeyContains("topicAuthor"),
                            Forum = forum,

                            SeedsCount = Convert.ToInt32(r.Texts.WhereKeyContains("seedmed")),
                            LeechesCount = Convert.ToInt32(r.Texts.WhereKeyContains("leechmed")),
                            DownloadsCount = Convert.ToInt32(r.Texts.WhereKeyContains("med1"))
                        }).ToList());
                }
                catch (Exception)
                {
                    throw new InconsistentHtmlParserException();
                }
                start += 50;
                Thread.Sleep(200);
            }

            return new ForumInfo
                {
                    Forums = new List<ForumInfo>(),
                    Topics = topics
                };
        }

        private string GetPageContent(string url)
        {
            Client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            var content = Client.DownloadString(url);
            return content;
        }

        public override Stream GetTorrentFile(string url, out string filename)
        {
            int tryCounter = 5;
            WebResponse response;
            do
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.Headers.Add("Accept-Language", "ru-RU");
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                request.KeepAlive = true;
                request.Headers.Add("Pragma", "no-cache");
                request.Headers.Add(HttpRequestHeader.Cookie, Storage.Instance.Cookies);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                
                response = request.ToResponse();
                if (response.ContentType.Contains("text/html"))
                {
                    var str = response.GetString();
                    if (str.Contains("исчерпали суточный лимит"))
                    {
                        var distress = "ПЕЕЧАААЛЬ";
                    }
                    Storage.Instance.Cookies = string.Empty;
                    Thread.Sleep(50);
                }
                tryCounter--;
            }
            while (string.IsNullOrEmpty(Storage.Instance.Cookies) && tryCounter > 0);

            filename = response.ContentType.Substring("name=\"","\"",false);
            return response.GetResponseStream();
        }


        public Cookie GetCookies(ICredentials credential)
        {
            var creds = (credential as NetworkCredential).CheckNull("Credentials");
            Client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            
            // Unfortunatelly, for now isn't worked with rutracker.org
            //var values = new NameValueCollection();
            //values.Add("login_username", creds.UserName);
            //values.Add("login_password", creds.UserName);
            //values.Add("login", "%C2%F5%EE%E4");
            //Client.UploadValues(LOGIN_FORM_URL, values);

            var request = (HttpWebRequest)WebRequest.Create("http://login.rutracker.org/forum/login.php");
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.Referer = "http://login.rutracker.org/forum/login.php";
            request.Headers.Add("Accept-Language", "ru-RU");
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.KeepAlive = true;
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add(HttpRequestHeader.Cookie, "spylog_test=1");
            request.AutomaticDecompression = DecompressionMethods.GZip;

            request.AllowAutoRedirect = false;

            request.CookieContainer = new CookieContainer();
            var creds2 = (credential as NetworkCredential).CheckNull("Credentials");

            var sQueryString = "login_username=" + HttpUtility.UrlEncode(creds.UserName, Encoding.Default) + "&" +
                "login_password=" + HttpUtility.UrlEncode(creds.Password, Encoding.Default) + "&login=%C2%F5%EE%E4";

            var byteArr = Encoding.GetEncoding(1251).GetBytes(sQueryString);
            request.ContentLength = byteArr.Length;
            request.GetRequestStream().Write(byteArr, 0, byteArr.Length);

            var response = request.ToResponse();
            if (response.ContentLength > 0)
            {
                var content = response.GetString();
                if (content.Contains("http://static.rutracker.org/captcha"))
                {
                    //<div><img src="http://static.rutracker.org/captcha/0/36/b4baa24342b680282a8a02048472bd1c.jpg?364017591" width="120" height="72" alt="pic" /></div>
                    //<div>
                    //<input type="hidden" name="cap_sid" value="qPAmLkxHKgW1hZONEG37" />
                    //<input type="text" name="cap_code_00c20a1ddd0d925ef10a82b1e661510b" value="" size="25" class="bold" />
                    //</div>
                    //
                    //redirect=index.php&login_username=[%username%]&login_password=[%password%]&cap_sid=qPAmLkxHKgW1hZONEG37&cap_code_00c20a1ddd0d925ef10a82b1e661510b=8k8dc&login=%C2%F5%EE%E4
                    var captchaUrl = content.Substring("http://static.rutracker.org/captcha", "?");
                    var captchaSid = content.Substring("name=\"cap_sid\" value=\"", "\"", true, 22);
                    var captchaCode = content.Substring("name=\"cap_code", "\"", true, 22);

                    var newCreds = GetCaptcha(creds, captchaUrl);
                    credential = new NetworkCredential(newCreds.Credential.UserName, newCreds.Credential.SecurePassword);

                    sQueryString = "redirect=index.php&login_username=" + HttpUtility.UrlEncode(newCreds.Credential.UserName, Encoding.Default) + "&" + "login_password=" +
                        HttpUtility.UrlEncode(newCreds.Credential.Password, Encoding.Default) + "&cap_sid=" + captchaSid + "&" + captchaCode + "=" + "Captcha" + "&login=%C2%F5%EE%E4";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(response.Headers["Set-Cookie"]))
                {
                    var cookie = (response as HttpWebResponse).Cookies[0];
                    return cookie;
                    //return response.Headers["Set-Cookie"].Substring("bb_data", ";") + "; spylog_test=1";
                }
            }
            throw new ArgumentException("Error in obtaining cookies. Something wrong with request's parameters: " + Environment.NewLine + "Request: " + request);
        }
    }
}
