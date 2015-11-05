using System.Collections.Generic;

namespace RutrackerManager.Common.Models
{
    public class ForumDto
    {
        public string _id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public List<TopicDto> Topics { get; set; }

        public ForumDto(string id, string link, string name, List<TopicDto> topics)
        {
            _id = id;
            Link = link;
            Name = name;
            Topics = topics;
        }
    }
}
