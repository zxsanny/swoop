using System.Configuration;
using Autofac;
using uHelper.Extensions;
using uHelper.webAPI;
using uHelper.webAPI.Rutracker;

namespace uHelper.Modules
{
    public class MainRegistrationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<RutrackerInfoProvider>().As<ITrackerInfoProvider>();
        }
    }
}
