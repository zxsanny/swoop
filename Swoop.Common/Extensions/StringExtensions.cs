﻿using System;
using System.Linq;
using System.Security;
using System.Web;

namespace Swoop.Common.Extensions
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

        public static int GetBoardDocumentId(this string url)
        {
            if (url.Length < 6)
                throw new ArgumentException("Wrong PHPBoard url!", "url");
            var lastSix = url.Substring(url.Length - 6, 6);
            
            int num = 0;
            int.TryParse(lastSix, out num);
            return num;
        }
    }
}
