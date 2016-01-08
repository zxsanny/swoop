using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Swoop.Common.Models;
using Swoop.Common.Repositories;

namespace Swoop.MongoRepository
{
    public class TrackerRepository : ITrackerRepository
    {
        private readonly IMongoCollection<TrackerInfo> trackers;
        
        public TrackerRepository(IMongoDatabase database)
        {
            BsonClassMap.RegisterClassMap<TrackerInfo>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.TrackerName);
            });

            trackers = database.GetCollection<TrackerInfo>("trackers");
            
        }

        public List<TrackerInfo> GetAll()
        {
            return trackers.AsQueryable().ToList();
        }
        
        public TrackerInfo GetTrackerInfo(string trackerName)
        {
            return trackers.AsQueryable().FirstOrDefault(x => x.TrackerName == trackerName);
        }
        
        public void Save(TrackerInfo info)
        {
            var tracker = trackers.AsQueryable().FirstOrDefault(x => x.TrackerName == info.TrackerName);
            if (tracker == null)
                trackers.InsertOneAsync(info);
            else
                trackers.UpdateOneAsync(x => x.TrackerName == info.TrackerName,
                    Builders<TrackerInfo>.Update
                        .Set(x => x.SeedTemplate, info.SeedTemplate)
                        .Set(x => x.MagnetTrackers, info.MagnetTrackers));
        }

        public void SaveCheckPoint(TrackerInfo info)
        {
            SaveCheckPoint(info.TrackerName, info.Checkpoint);
        }
        public void SaveCheckPoint(string trackerName, int checkpoint)
        {
            trackers.FindOneAndUpdateAsync(x => x.TrackerName == trackerName,
                Builders<TrackerInfo>.Update.Set(x => x.Checkpoint, checkpoint));
        }
    }
}
