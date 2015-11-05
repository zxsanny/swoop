using System.Net;
using System.Security;
using Autofac;
using Autofac.Core;

namespace RutrackerManager.Api
{
    public class RutrackerModule : Module
    {
        private readonly string Username;
        private readonly SecureString Password;

        public RutrackerModule(string username, SecureString password)
        {
            Username = username;
            Password = password;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(ctx => new NetworkCredential(Username, Password)).Named<ICredentials>("creds");
            builder.RegisterType<RutrackerInfoProvider>().As<RutrackerInfoProvider>().WithParameter(ResolvedParameter.ForNamed<ICredentials>("creds"));
        }
    }
}