using System;
using System.ComponentModel;

namespace Swoop.Common.Models
{
    public class SeedDecorator : Decorator<Seed>
    {
        private readonly TrackerInfo trackerInfo;

        public SeedDecorator(Seed model, TrackerInfo trackerInfo) : base(model)
        {
            this.trackerInfo = trackerInfo;
        }
        public DateTime? Created { get { return model.Created; } }
        public string Category { get { return model.Category; } }
        public string Title { get { return model.Title; } }
        public double SizeMb { get { return model.SizeMb; } }

        [Browsable(false)]
        public string Url { get { return trackerInfo.SeedTemplate + model.Id; } }

        [Browsable(false)]
        public string MagnetLink
        {
            get { return string.Concat("magnet:?xt=urn:btih:", model.Hash, "&tr=", trackerInfo.MagnetTrackers); } 
        }
    }
}
