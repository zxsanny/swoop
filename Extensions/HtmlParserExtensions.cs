using System;
using System.Collections.Generic;
using System.Linq;
using System.Monads;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using uHelper.Extensions.Excepitons;

namespace uHelper.Extensions
{
    public static class HtmlParserExtensions
    {
        public static List<List<string>> ToTable(this HtmlNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            var parsedTable = new List<List<string>>();
            var rows = node.Descendants("tr").ToArray();
            if (!rows.Any())
                throw new InconsistentHtmlLayout();

            foreach (var row in rows)
            {
                var curRow = new List<string>();
                foreach (var td in row.Descendants("td"))
                    curRow.AddRange(td.Descendants("#text").Select(x => x.InnerText.RefineHtml()).Where(x => !string.IsNullOrEmpty(x)).ToList());
                parsedTable.Add(curRow);
            }
            return parsedTable;
        }

        public static List<HtmlRow> ToTable2(this HtmlNode table)
        {
            if (table == null)
                throw new ArgumentNullException("table");

            var parsedTable = new List<HtmlRow>();
            var rows = table.Descendants("tr").ToArray();
            if (!rows.Any())
                throw new InconsistentHtmlLayout();
            
            foreach (var row in rows)
            {
                var tableRow = new HtmlRow();
                int currentNum = 1;
                int currentLink = 1;
                int tdNum = 1;
                foreach (var td in row.Descendants("td"))
                {
                    foreach (var node in td.Descendants())
                    {
                        var link = node.Attributes["href"];
                        if (link != null)
                        {
                            var xx = string.Join(".", node.Attributes.Where(x => x.Name != "href").Select(x => x.Value)) + ".link" + currentLink++;
                            tableRow.Links.Add(xx, link.Value);
                        }
                        else
                        {
                            var a = node.Attributes["class"].With(x => x.Value);//.CheckNullWithDefault("cl");
                            var b = node.InnerText.RefineHtml();
                            if (a == null || string.IsNullOrEmpty(b))
                                continue;
                            if (tableRow.Texts.ContainsKey(a))
                                a += currentNum++;
                            tableRow.Texts.Add(a,b);
                        }
                    }
                    tableRow.Texts.Add("td" + tdNum++, td.InnerText.RefineHtml());
                }
                if (tableRow.Texts.Any())
                    parsedTable.Add(tableRow);
            }
            return parsedTable;
        }

        public static string ToText(this HtmlNode node, bool distinct = false)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            var texts = node.Descendants("#text").Select(x => x.InnerText).ToArray();
            if (distinct)
                texts = texts.Distinct(new StringEqualityComparer()).ToArray();

            return string.Join("", texts).RefineHtml();
        }
        public static string ToLink(this HtmlNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            
            var link = node.With(x => x.Attributes["href"]);
            if (link == null)
                throw new InconsistentHtmlLayout();

            return link.Value;
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
