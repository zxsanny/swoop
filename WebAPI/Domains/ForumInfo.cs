using System.Collections.Generic;

namespace uHelper.webAPI.Domains
{
    public class ForumInfo
    {
        public List<ForumInfo> Forums { get; set; }
        public List<TopicInfo> Topics { get; set; } 
    }
}
