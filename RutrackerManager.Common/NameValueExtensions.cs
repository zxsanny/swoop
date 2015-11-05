using System.Collections.Specialized;
using System.Linq;

namespace RutrackerManager.Common
{
    public static class NameValueExtensions
    {
        public static string GetValue(this NameValueCollection settings, string key, string defaultValue = "")
        {
            if (!settings.AllKeys.Any(x => x == key))
                return defaultValue;
            return settings[key];
        }

    }
}
