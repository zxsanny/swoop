using System;
using System.Configuration;
using System.Windows.Forms;
using Autofac;
using RutrackerManager.Api;
using RutrackerManager.Common;

namespace RutrackerManager.Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RutrackerViewForm>().As<RutrackerViewForm>();
            builder.RegisterModule(new RutrackerModule(
                ConfigurationManager.AppSettings.GetValue("username", "zxsanny"),
                ConfigurationManager.AppSettings.GetValue("password", "ifx342vfns").ToSecureString()));

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(scope.Resolve<RutrackerViewForm>());    
            }
        }
    }
}
