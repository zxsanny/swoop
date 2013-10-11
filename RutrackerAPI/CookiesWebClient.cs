using System;
using System.Monads;
using System.Net;

namespace uHelper.webAPI.Rutracker
{
    public class CookiesWebClient : WebClient
    {
        private readonly Func<ICredentials, Cookie> getCookies;
        private readonly NetworkCredential credential;

        public CookiesWebClient(Func<ICredentials, Cookie> getCookies, NetworkCredential credential)
        {
            this.getCookies = getCookies;
            this.credential = credential;
            
            Credentials = credential;
        }

        private Cookie Cookie { get; set; }
    
        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            try
            {
                var response = base.GetWebResponse(request, result);
                return response;
            }
            catch (Exception)
            {
                Cookie = getCookies(Credentials);
                
                return base.GetWebResponse(request, result);
            }
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            ((HttpWebRequest)request).CookieContainer.Add(Cookie);
            return base.GetWebResponse(request);
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            if (Cookie == null)
            {
                Cookie = getCookies(credential);
            }
            var request = (base.GetWebRequest(address) as HttpWebRequest).CheckNull("request");
            request.CookieContainer.Add(Cookie);
            return request;
        }
    }
}