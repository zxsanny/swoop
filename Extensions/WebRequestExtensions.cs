using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using uHelper.Extensions.Excepitons;

namespace uHelper.Extensions
{
    public static class WebRequestHelper
    {
        public static WebRequest CreateRequest(NetworkCredential credential, string topicUrl, string cookies)
        {
            var request = (HttpWebRequest)WebRequest.Create(topicUrl);
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            request.Accept = "text/html, application/xhtml+xml, */*";

            request.Headers.Add("Accept-Language", "ru-RU");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.KeepAlive = true;

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Pragma", "no-cache");
            
            request.Headers.Add(HttpRequestHeader.Cookie, cookies);

            return request;
        }

        public static ManualResetEvent AllDone = new ManualResetEvent(false);
        private static WebResponse currentResponse;

        public static WebResponse ToResponse(this WebRequest request, int msTimeOut = 6000)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            currentResponse = null;
            var result = request.BeginGetResponse(ResponseCallback, request);
            AllDone.WaitOne(msTimeOut);
            if (currentResponse == null)
                throw new WebException("Wrong request! Request: " + request);
            return currentResponse;

        }

        private static void ResponseCallback(IAsyncResult ar)
        {
            var request = (HttpWebRequest)ar.AsyncState;
            currentResponse = request.EndGetResponse(ar);
            if (currentResponse != null) 
                currentResponse.Close();
            AllDone.Set();
        }

        public static string GetString(this WebResponse response, Encoding encoding = null)
        {
            if (response == null)
                throw new ArgumentNullException("response");
            var stream = response.GetResponseStream();
            if (stream == null)
                throw new WebException("Error trying get stream of currentResponse! Response: " + response);
            if (encoding == null)
                encoding = Encoding.GetEncoding(1251);
            string content;
            try
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }
                response.Close();
            }
            catch (Exception)
            {
                throw new UnreadableStreamException();
            }
            
            return content;
        }
    }
}
