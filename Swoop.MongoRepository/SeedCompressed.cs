using System;
using Swoop.Common;
using Swoop.Common.Models;

namespace Swoop.MongoRepository
{
    public class SeedCompressed
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string TrackerName { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime? Created { get; set; }

        public string Uploader { get; set; }
        public double SizeMb { get; set; }
        
        public byte[] Description { get; set; }

        public SeedCompressed(Seed seed, byte[] description)
        {
            Id = seed.Id;
            Hash = seed.Hash;
            TrackerName = seed.TrackerName;
            Title = seed.Title;
            Category = seed.Category;
            Created = seed.Created;
            SizeMb = seed.SizeMb;
            
            Uploader = seed.Uploader;
            
            Description = description;
        }
    }
}
