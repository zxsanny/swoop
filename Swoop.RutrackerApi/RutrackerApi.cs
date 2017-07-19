using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Monads;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Web;
using HtmlAgilityPack;
using log4net;
using Swoop.Common;
using Swoop.Common.Extensions;
using Swoop.Common.Models;
using Swoop.Common.Repositories;

namespace Swoop.RutrackerApi
{
    public class RutrackerApi : BaseTrackerApi
    {
        public ICredentials credentials;
        private readonly ILog logger;
        public ISeedsRepository repository;

        private CookiesWebClient client;
        protected override WebClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new CookiesWebClient(GetCookie(), logger);
                    client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                }
                return client;
            }
        }

        public override TrackerInfo TrackerInfo
        {
            get
            {
                return new TrackerInfo("Rutracker", "http://rutracker.org/forum/viewtopic.php?t=", "http://bt.rutracker.cc/ann?magnet");
            }
        }

        public RutrackerApi(ILog logger, params Tuple<string, string>[] @params) : base(logger)
        {
            this.logger = logger;

            if (@params == null || @params.Length == 0)
                return;
            
            string username = "";
            string password = "";
            foreach (var tuple in @params)
            {
                switch (tuple.Item1)
                {
                    case "Rutracker.username":
                        username = tuple.Item2;
                        break;
                    case "Rutracker.password":
                        password = tuple.Item2;
                        break;
                }
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Constructor of Rutracker API module should get username and password in parameters!");

            credentials = new NetworkCredential(username, password);
        }
        
        public override Seed GetSeed(int id)
        {
            var page = GetPageContent(id);

            page = page.Replace("<wbr>", "");
            var doc = new HtmlDocument();
            doc.LoadHtml(page);
            var document = doc.DocumentNode;
                
            var hashNode = document.SelectSingleNode("//span[@id='tor-hash']");
            var category = document.SelectSingleNode("//span[@class='brand-bg-white']").ToText();
            if (hashNode == null)
            {
                if (document.InnerText.IndexOf("Тема не найдена", StringComparison.Ordinal) > 0)
                    return null;
                if (category == null)
                    throw new Exception("Can't find hash and navigation bar!");
                return null;
            }
            var hash = hashNode.InnerText;

            category = category.Substring(31, category.Length - 31);
            
            var title = document.Descendants("title").Single().InnerText;
            title = WebUtility.HtmlDecode(title.Substring(0, title.Length - 17));
            
            var descriptionDiv = document.SelectSingleNode("//div[@class='post_body']");
            
            var torReged = descriptionDiv.SelectSingleNode("//div[@id='tor-reged']");
            var createdDate = GetDate(torReged);
            
            var sizeStr = torReged.SelectSingleNode("//span[@id='tor-size-humn']").InnerText;
            var size = GetSizeMB(sizeStr);
            descriptionDiv.ChildNodes.Remove(torReged);

            var descriptionHtml = descriptionDiv.InnerHtml;
            var images = descriptionDiv.GetByClass("var", "postImg");
            var isFirst = true;
            foreach (var image in images)
            {
                var newImage = string.Concat("<img src=\"", image.Attributes["title"].Value, "\" alt=\"picture\">");
                if (isFirst)
                {
                    newImage = string.Concat(newImage, "<br>" + Environment.NewLine);
                    isFirst = false;
                }
                descriptionHtml = descriptionHtml.Replace(image.OuterHtml, newImage);
            }
            
            var longWraps = descriptionDiv.GetByClass("div", "sp-wrap", true).Where(x => x.InnerHtml.Length > 3000).ToList();
            foreach (var wrap in longWraps)
                descriptionHtml = descriptionHtml.Replace(wrap.OuterHtml, "<br>" + Environment.NewLine);
            
            descriptionHtml = descriptionHtml
                .Replace("<span class=\"post-br\"><br></span>", "<br>" + Environment.NewLine)
                .Replace("<!--/tor-reged-->", "")
                .Replace(descriptionDiv.GetByClass("div", "clear").FirstOrDefault().With(x=>x.OuterHtml), "")
                .Replace(descriptionDiv.GetByClass("div", "spacer_12").FirstOrDefault().With(x=>x.OuterHtml), "")
                .Trim();
            
            var uploader = document.SelectSingleNode("//*[contains(@class,'nick-author')]").ToText(distinct: true);

            return new Seed(TrackerInfo, id, hash, category, title, createdDate, descriptionHtml, size, uploader);
        }

        private DateTime? GetDate(HtmlNode torReged)
        {
            //Rutracker uses VERY impressive date format: [ 30-Окт-15 15:32 ]
            if (torReged == null)
                return null;

            var dateStartIndex = torReged.InnerText.IndexOf('[');
            var dateEndIndex = torReged.InnerText.IndexOf(']');
            if (dateStartIndex == -1 || dateEndIndex == -1)
                return null;
            var dateStr = torReged.InnerText.Substring(dateStartIndex, dateEndIndex - dateStartIndex).Trim('[', ']').Trim();
            DateTime date;
            var provider = CultureInfo.CreateSpecificCulture("ru-RU");
            if (DateTime.TryParseExact(dateStr, "dd-MMM-yy HH:mm", provider, DateTimeStyles.None, out date))
                return date;
            return null;
        }

        public double GetSizeMB(string text)
        {
            var sizesDict = new Dictionary<string, double>
            {
                {"B", 0.000001},
                {"KB", 0.001},
                {"MB", 1},
                {"GB", 1024},
                {"TB", 1024*1024}
            };
            var s = text.Replace("&nbsp;", " ").ToUpperInvariant().Split(' ');
            if (s.Length < 2)
                return -1;
            double num;
            if (!sizesDict.ContainsKey(s[1]))
                return -1;

            if (double.TryParse(s[0], out num))
                return num * sizesDict[s[1]];
            return -1;
        }

        //magnet:?xt=urn:btih:78D9D0AFA3D2B51EBAD5F4AC6A321A6036684E0F&amp;tr=http%3A%2F%2Fbt.rutracker.cc%2Fann
        //magnet:?xt=urn:btih:AEE7B06E4591037EA18049EEAF04E07E24EC663B&amp;tr=http%3A%2F%2Fbt.rutracker.cc%2Fann

        //magnet:?xt=urn:btih:90bb4db6458d531d2e694e55c2540ec70d309f56&amp;dn=rutor.org&amp;tr=udp://opentor.org:2710&amp;tr=udp://bt.rutor.org:2710&amp;tr=http://retracker.local/announce
        //magnet:?xt=urn:btih:f3dda6cbbbcec3d1788b49de348667471c15268b&amp;dn=rutor.org&amp;tr=udp://opentor.org:2710&amp;tr=udp://bt.rutor.org:2710&amp;tr=http://retracker.local/announce

        private Cookie GetCookie()
        {
            var creds = (credentials as NetworkCredential).CheckNull("Credentials");
            //var webClient = new WebClient();
            //webClient.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            
            var request = (HttpWebRequest)WebRequest.Create("https://rutracker.org/forum/login.php");
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.Referer = "https://rutracker.org/forum/login.php";
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
