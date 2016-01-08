using System;
using System.Monads;
using System.Net;
using log4net;

namespace Swoop.Common
{
    public class CookiesWebClient : WebClient
    {
        private readonly Cookie cookie;
        private readonly ILog logger;

        public CookiesWebClient(Cookie cookie, ILog logger)
        {
            this.cookie = cookie;
            this.logger = logger;
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
                Cookie = cookie;
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
                logger.Info("Getting cookies...");
                Cookie = cookie;
                logger.Info("Cookes are set");
            }
            var request = (base.GetWebRequest(address) as HttpWebRequest).CheckNull("request");
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(Cookie);
            return request;
        }
    }
}
