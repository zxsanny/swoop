using System;
using System.Collections.Generic;

namespace RutrackerManager.Common.Models
{
    public class TopicDto
    {
        public string _id { get; set; }
        public string TopicLink { get; set; }
        public int TopicId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public TopicStatus Status { get; set; }
        public string Uploader { get; set; }
        public string SizeStr { get; set; }
        public double SizeMb { get; set; }

        public string TorrentLink { get; set; }
        public Guid TorrentId { get; set; }
        
        public string Image { get; set; }
        public List<string> Images { get; set; }

        public TopicDto(string topicLink, int topicId, string name, string description, TopicStatus status, string uploader, string sizeStr, double sizeMb, string torrentLink, string image = null, List<string> images = null)
        {
            TopicLink = topicLink;
            TopicId = topicId;
            
            Name = name;
            Description = description;
            Status = status;
            Uploader = uploader;
            SizeStr = sizeStr;
            SizeMb = sizeMb;
            TorrentLink = torrentLink;
            
            Image = image;
            Images = images;
        }

        public string GetTorrentName()
        {
            return "[rutracker.org]." + TopicId + ".torrent";
        }
    }
}
