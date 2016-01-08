using System;
using System.Collections.Generic;
using System.Linq;
using System.Monads;
using HtmlAgilityPack;

namespace Swoop.Common.Extensions
{
    public static class HtmlParserExtensions
    {
        public static List<HtmlNode> GetById(this HtmlNode node, string element, string id)
        {
            if (node == null)
                return new List<HtmlNode>();
            var descendants = node.Descendants(element);
            return descendants == null ? new List<HtmlNode>() : descendants.Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value == id).ToList();
        }

        public static List<HtmlNode> GetByClass(this HtmlNode node, string element, string className, bool onlyFirstLevel = false)
        {
            if (node == null)
                return new List<HtmlNode>();
            var descendants = node.Descendants(element);
            if (descendants == null)
                return new List<HtmlNode>();
            descendants = descendants.Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains(className));
            if (onlyFirstLevel)
                descendants = descendants.Where(x => x.ParentNode == node);
            return descendants.ToList();
        } 

        public static string ToText(this HtmlNode node, bool distinct = false)
        {
            if (node == null)
                return "";

            var texts = node.Descendants("#text").Select(x => x.InnerText).ToArray();
            if (distinct)
                texts = texts.Distinct(new StringEqualityComparer()).ToArray();

            return string.Join("", texts).RefineHtml();
        }
        
        public class StringEqualityComparer : EqualityComparer<string>
        {
            public override bool Equals(string x, string y)
            {
                return x.Equals(y);
            }

            public override int GetHashCode(string obj)
            {
                return obj != null ? obj.GetHashCode() : 0;
            }
        }
    }
}
