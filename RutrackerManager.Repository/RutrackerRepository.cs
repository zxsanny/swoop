using System.IO;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using RutrackerManager.Common.Models;

namespace RutrackerManager.Repository
{
    public interface IRutrackerRepository
    {
    }

    public class RutrackerRepository : IRutrackerRepository
    {
        private readonly MongoCollection<ForumDto> ForumCollection;
        private readonly MongoGridFS gridFs;
        public RutrackerRepository(MongoDatabase database)
        {
            ForumCollection = database.GetCollection<ForumDto>("forums");
            gridFs = database.GridFS;
        }

        public void CreateForum(ForumDto forum)
        {
            ForumCollection.Save(forum);
        }

        public void AddTopic(ForumDto forum, TopicDto topic, byte[] torrent)
        {
            using (var stream = new MemoryStream(torrent))
            {
                var fileInfo = gridFs.Upload(stream, topic.GetTorrentName());
                topic.TorrentId = fileInfo.Id.AsGuid;

                ForumCollection.Update(Query<ForumDto>.EQ(x => x._id, forum._id),
                    Update<ForumDto>.AddToSet(x => x.Topics, topic));
            }
        }
    }
}
