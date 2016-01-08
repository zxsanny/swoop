using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Swoop.Common.Extensions
{
    public static class NameValueExtensions
    {
        public static string GetValue(this NameValueCollection settings, string key, string defaultValue = "")
        {
            if (!settings.AllKeys.Any(x => x == key))
                return defaultValue;
            return settings[key];
        }

        public static IEnumerable<Tuple<string, string>> GetValuesPattern(this NameValueCollection settings, string startPattern)
        {
            return settings.AllKeys.Where(x => x.StartsWith(startPattern))
                .Select(x => new Tuple<string, string>(x, settings[x]));
        }
    }
}
