using System;
using System.Collections.Generic;
using System.Globalization;

namespace uHelper.Extensions
{
    public static class SizeExtenstions
    {
        static readonly Dictionary<string, long> prefixes = new Dictionary<string, long>
            {
                {"B", 1},
                {"KB", 1024},
                {"MB", 1024*1024},
                {"GB", 1024*1024*1024},
                {"TB", 1024L*1024L*1024L*1024L}
            };

        public static long GetSizeInBytes(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            var s = text.ToUpperInvariant().Split(new[]{' '}, StringSplitOptions.None);
            return (long)(double.Parse(s[0], CultureInfo.InvariantCulture) * prefixes[s[1]]);
        }
    }
}
