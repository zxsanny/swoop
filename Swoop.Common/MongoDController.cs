using System;
using System.Diagnostics;
using System.IO;

namespace Swoop.Common
{
    public static class MongoDController
    {
        private static Process mongod;

        public static void Start()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var dbPath = Path.Combine(dir, "db");
            if (!Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);
            
            var start = new ProcessStartInfo
            {
                FileName = Path.Combine(dbPath, "mongod.exe"),
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "--dbpath " + dbPath + " --port " + 3789
            };

            mongod = Process.Start(start);
        }

        public static void Stop()
        {
            try
            {
                if (mongod != null)
                    mongod.Kill();
            }
            catch (Exception)
            {
                // if we can't kill mongod - so let it be...
            }
        }
    }
}
