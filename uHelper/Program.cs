using System;
using System.Windows.Forms;
using Autofac;
using uHelper.Extensions;
using uHelper.Modules;
using uHelper.Properties;

namespace uHelper
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
            builder.RegisterType<MainForm>().As<MainForm>();
            builder.RegisterModule(new MainRegistrationsModule());

            builder.RegisterType<UHelperSettingsProvider>().As<ISettingsProvider>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(scope.Resolve<MainForm>());    
            }
        }

        public static Settings UHelperSettings { get; set; }
    }
}
