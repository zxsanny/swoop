using HtmlAgilityPack;

namespace RutrackerManager.Common.Models
{
    public class LinkDto
    {
        public string Name { get; set; }
        public string Link { get; set; }

        public LinkDto(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public LinkDto(HtmlNode node)
        {
            Name = node.InnerText;
            Link = node.Attributes["href"].Value;
        }
    }
}
