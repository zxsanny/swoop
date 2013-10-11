using System.Net;

namespace uHelper.webAPI.Domains
{
    public class CredentialAndCaptcha
    {
        public NetworkCredential Credential { get; set; }
        public string Code { get; set; }

        public CredentialAndCaptcha(NetworkCredential credential, string code)
        {
            Credential = credential;
            Code = code;
        }
    }
}
