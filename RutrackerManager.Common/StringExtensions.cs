using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Web;

namespace RutrackerManager.Common
{
    public static class StringExtensions
    {
        public static string Substring(this string str, string beginStr, string endStr, bool includeBeginStr = true, int shift = 0)
        {
            var startIndex = str.IndexOf(beginStr, StringComparison.Ordinal) + shift;
            if (startIndex == -1)
                throw new ArgumentException(string.Format("string {0} does not contains substring {1}", str, beginStr));
            if (startIndex + shift > str.Length)
                return "";
            startIndex += shift;
            startIndex = Math.Max(0, startIndex);

            var endIndex = str.IndexOf(endStr, startIndex + beginStr.Length, StringComparison.Ordinal);
            if (endIndex == -1)
                throw new ArgumentException(
                    string.Format("string {0} does not contains substring {1} after substring {2}", str, endStr,
                                  beginStr));
            if (!includeBeginStr)
                startIndex += beginStr.Length;
            
            return str.Substring(startIndex, endIndex - startIndex);
        }

        public static SecureString ToSecureString(this string s)
        {
            var secureString = new SecureString();
            s.ToCharArray().ToList().ForEach(secureString.AppendChar);
            return secureString;
        }
        
        public static string RefineHtml(this string str)
        {
            var s = HttpUtility.HtmlDecode(str.Replace("&nbsp;", " ").Replace(new[] {"\n", "\t"}, ""));
            if (s.Length == 1)
                s = s.Replace(new[] {".", "·"}, "");
            return s;
        }

        public static string Replace(this string str, string[] oldValues, string newValue)
        {
            return oldValues.Aggregate(str, (x, oldValue) => x.Replace(oldValue, newValue));
        }

        static readonly Dictionary<string, double> prefixes = new Dictionary<string, double>
            {
                {"B", 0.000001},
                {"KB", 0.001},
                {"MB", 1},
                {"GB", 1024},
                {"TB", 1024*1024}
            };

        public static double GetSizeInBytes(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            var s = text.ToUpperInvariant().Split(new[] { ' ' }, StringSplitOptions.None);
            return (long)(double.Parse(s[0], CultureInfo.InvariantCulture) * prefixes[s[1]]);
        }
    }
}
