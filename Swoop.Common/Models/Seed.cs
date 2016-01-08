using System;

namespace Swoop.Common.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string TrackerName { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public DateTime? Created { get; set; }

        public string Description { get; set; }
        public string Uploader { get; set; }
        public double SizeMb { get; set; }

        public Seed(TrackerInfo trackerInfo, int id, string hash, string category, string title, DateTime? created, string description, double sizeMb, string uploader)
        {
            TrackerName = trackerInfo.TrackerName;
            Id = id;
            Hash = hash;
            Category = category;
            Title = title;
            Created = created; 
            Description = description;
            SizeMb = sizeMb;
            
            Uploader = uploader;
        }
    }
}
