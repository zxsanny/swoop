using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using log4net;
using log4net.AutoFac;
using log4net.Config;
using Swoop.Common;
using Swoop.Common.Extensions;
using Swoop.Common.Models;
using Swoop.Common.Repositories;
using Swoop.Compressor;
using Swoop.MongoRepository;

namespace Swoop.Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            MongoDController.Start();

            var trackerInfos = new List<TrackerInfo>();

            var builder = new ContainerBuilder();
            builder.RegisterType<SwoopViewForm>().As<SwoopViewForm>();
            builder.RegisterModule(new MongoRepositoryModule(ConfigurationManager.ConnectionStrings["swoop"].ConnectionString));
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new CompressorModule());

            var forwardCheckCount = Convert.ToInt32(ConfigurationManager.AppSettings.GetValue("forward-check-count", "200"));

            var dir = AppDomain.CurrentDomain.BaseDirectory;

            var trackerAssemblies = new List<Assembly>();
            var files = Directory.GetFiles(dir, "*.dll");
            foreach (var file in files)
            {
                try
                {
                    trackerAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(file)));
                }
                catch (BadImageFormatException)
                {}
            }
            var types = trackerAssemblies.SelectMany(a =>
            {
                return (IEnumerable<Type>) a.GetTypes();
            }
                ).Where(x => x.IsSubclassOf(typeof(BaseTrackerApi))).ToList();
            foreach (var classType in types)
            {
                var trackerApi = (BaseTrackerApi)Activator.CreateInstance(classType, new object[] {null});
                trackerInfos.Add(trackerApi.TrackerInfo);

                var trackerSettings = ConfigurationManager.AppSettings.GetValuesPattern(trackerApi.TrackerInfo.TrackerName).ToArray();
                builder.RegisterType(classType).As<BaseTrackerApi>().Named<BaseTrackerApi>(trackerApi.TrackerInfo.TrackerName).WithParameter("params", trackerSettings);
                builder.RegisterType<TrackerGrabber>().As<ITrackerGrabber>().WithParameter(ResolvedParameter.ForNamed<BaseTrackerApi>(trackerApi.TrackerInfo.TrackerName))
                    .WithParameter("forwardCheckCount", forwardCheckCount).Named<ITrackerGrabber>(trackerApi.TrackerInfo.TrackerName + "_grabber").SingleInstance();
            }
            
            var container = builder.Build();

            var trackerRepostitory = container.Resolve<ITrackerRepository>();
            foreach (var trackerInfo in trackerInfos)
                trackerRepostitory.Save(trackerInfo);

            using (var scope = container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    Application.Run(scope.Resolve<SwoopViewForm>());
                }
                catch (Exception ex)
                {
                    container.Resolve<ILog>().Error("", ex);
                    throw;
                }
            }
            MongoDController.Stop();
        }
    }
}
