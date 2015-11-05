using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Monads;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Web;
using HtmlAgilityPack;
using RutrackerManager.Common;
using RutrackerManager.Common.Models;

namespace RutrackerManager.Api
{
    //public interface ITrackerInfoProvider
    //{
    //    TopicDto GetTopic(string topicUrl);
    //    Stream GetTorrentFile(string url, out string filename);
    //    void ContinueCollect();
    //}

    public class RutrackerInfoProvider
    {
        public ICredentials Credentials { get; set; }
        private readonly CookiesWebClient Client;

        private const string MAIN_URL = "http://rutracker.org/forum/index.php";
        
        private const string FORUM_LINK_TEMPLATE = "viewforum.php?f=";
        private const string TOPIC_LINK_TEMPLATE = "viewtopic.php?t=";

        private const int SIZE_AND_DOWNLOADS_ROW_NUMBER = 1;
        private const int SEEDS_AND_LEECHES_ROW_NUMBER = 2;

        public RutrackerInfoProvider(ICredentials credentials)
        {
            Credentials = credentials;
            Client = new CookiesWebClient(GetCookies, credentials);
        }

        public TopicDto GetTopic(string topicLink)
        {
            var topicId = Convert.ToInt32(topicLink.Substring(topicLink.Length - 6, 6));
            var content = GetPageContent(topicLink);
            content = content.Replace("<wbr>", "");
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            
            var title = doc.DocumentNode.SelectSingleNode("//h1[@class='maintitle']").ToText();
            var description = doc.DocumentNode.SelectSingleNode("//div[@class=post_body]").ToText();

            var uploader = doc.DocumentNode.SelectSingleNode("//p[@class='nick nick-author']").ToText(distinct: true);

            var data = doc.DocumentNode.SelectSingleNode("//table[@class='forumline dl_list']").ToTable2();
            
            //Размер:  18.57 GB   |   Зарегистрирован:  3 года 6 месяцев   |   .torrent скачан:  11701 раз
            var sizeAndDownloads = data[SIZE_AND_DOWNLOADS_ROW_NUMBER].Texts.WhereKeyContains("td1");
            var sizeStr = sizeAndDownloads.Substring("Размер:", "|", false).Trim();
            
            var statusText = doc.DocumentNode.SelectSingleNode("//span[contains(concat(' ',@class,' '),'tor-icon')]").InnerText.RefineHtml();
            var status = statusText.GetStatus();

            var torrentLink = doc.DocumentNode.SelectSingleNode("//a[@class='dl-stub dl-link']").ToLink();

            return new TopicDto(topicLink, topicId, title, description, status, uploader, sizeStr, sizeStr.GetSizeInBytes(), torrentLink);
        }

        public void ContinueCollect()
        {
            CollectRecursiveForums(MAIN_URL);
        }

        private void CollectRecursiveForums(string url)
        {
            var mainPage = GetPageContent(MAIN_URL);
            var doc = new HtmlDocument();
            doc.LoadHtml(mainPage);
            var links = doc.DocumentNode.SelectNodes("//a[@href]").Select(x => new LinkDto(x)).ToList();
            var forums = links.Where(x => x.Link.StartsWith(FORUM_LINK_TEMPLATE)).ToList();
            var topics = links.Where(x => x.Link.StartsWith(TOPIC_LINK_TEMPLATE)).ToList();
            foreach (var topic in topics)
            {
                GetTopic(topic.Link);
            }

            foreach (var forum in forums)
                CollectRecursiveForums(forum.Link);
        }

        private string GetPageContent(string url)
        {
            Client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            var content = Client.DownloadString(url);
            return content;
        }

        public Stream GetTorrentFile(string url, out string filename)
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
                request.Headers.Add(HttpRequestHeader.Cookie, GetCookies(Credentials).Value);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                
                response = request.ToResponse();
                if (response.ContentType.Contains("text/html"))
                {
                    var str = response.GetString();
                    if (str.Contains("исчерпали суточный лимит"))
                        throw new Exception("Exceed daily torrent download limit!");
                    Thread.Sleep(50);
                }
                tryCounter--;
            }
            while (string.IsNullOrEmpty(GetCookies(Credentials).Value) && tryCounter > 0);

            filename = response.ContentType.Substring("name=\"","\"",false);
            return response.GetResponseStream();
        }

        // Unfortunatelly, for now isn't worked with rutracker.org
        //var values = new NameValueCollection();
        //values.Add("login_username", creds.UserName);
        //values.Add("login_password", creds.UserName);
        //values.Add("login", "%C2%F5%EE%E4");
        //Client.UploadValues(LOGIN_FORM_URL, values);

        public Cookie GetCookies(ICredentials credential)
        {
            var creds = (credential as NetworkCredential).CheckNull("Credentials");
            Client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            
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

            var sQueryString = "login_username=" + HttpUtility.UrlEncode(creds.UserName, Encoding.Default) + "&" +
                "login_password=" + HttpUtility.UrlEncode(creds.Password, Encoding.Default) + "&login=%C2%F5%EE%E4";

            var byteArr = Encoding.GetEncoding(1251).GetBytes(sQueryString);
            request.ContentLength = byteArr.Length;
            request.GetRequestStream().Write(byteArr, 0, byteArr.Length);

            var response = request.ToResponse();
            if (response.ContentLength > 0)
                throw new InvalidCredentialException();

            if (string.IsNullOrEmpty(response.Headers["Set-Cookie"]))
                throw new InvalidCredentialException("Error in obtaining cookies. Something wrong with request's parameters: " + Environment.NewLine + "Request: " + request);
            
            var cookie = (response as HttpWebResponse).Cookies[0];
            return cookie;
        }
    }
}
