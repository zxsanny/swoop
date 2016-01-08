using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Swoop.Common.Extensions;
using Swoop.Common.Models;
using Swoop.Common.Repositories;
using Swoop.Compressor;

namespace Swoop.MongoRepository
{
    public class SeedsMongoRepository : ISeedsRepository
    {
        private readonly ICompressor compressor;
        private readonly IMongoCollection<SeedCompressed> seeds;
        
        public SeedsMongoRepository(IMongoDatabase database, ICompressor compressor)
        {
            this.compressor = compressor;
            BsonClassMap.RegisterClassMap<Seed>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.Id);
            });
            
            seeds = database.GetCollection<SeedCompressed>("seeds");
            seeds.Indexes.CreateOneAsync(Builders<SeedCompressed>.IndexKeys.Text(x => x.Title));
            seeds.Indexes.CreateOneAsync(Builders<SeedCompressed>.IndexKeys.Ascending(x => x.Created));
            seeds.Indexes.CreateOneAsync(Builders<SeedCompressed>.IndexKeys.Ascending(x => x.SizeMb));
            seeds.Indexes.CreateOneAsync(Builders<SeedCompressed>.IndexKeys.Hashed(x => x.Category));
        }

        public void AddSeed(Seed seed)
        {
            var descriptionBytes = compressor.Compress(seed.Description);
            seeds.InsertOneAsync(new SeedCompressed(seed, descriptionBytes));
        }

        public bool IsSeedExists(int id)
        {
            var task = seeds.Find(x => x.Id == id).CountAsync();
            task.Wait();
            return task.Result > 0;
        }

        private Seed DecompressSeed(SeedCompressed seed)
        {
            var description = compressor.Decompress(seed.Description);
            return new Seed(new TrackerInfo(seed.TrackerName, "", ""),  seed.Id, seed.Hash, seed.Category, seed.Title, seed.Created, description, seed.SizeMb, seed.Uploader);
        }

        public List<Seed> Find(string filter = "", IList<string> categories = null, SortInfo sortInfo = null)
        {
            var search = seeds.AsQueryable();
            
            if (!string.IsNullOrEmpty(filter))
            {
                int num;
                if (int.TryParse(filter, out num))
                    search = search.Where(x => x.Id == num);
                else
                {
                    filter = filter.Trim().ToLowerInvariant();
                    if (!string.IsNullOrEmpty(filter))
                        search = search.Where(x => x.Title.ToLowerInvariant().Contains(filter));
                }
            }
            if (categories != null && categories.Any())
                search = search.Where(x => categories.Contains(x.Category));
            if (sortInfo != null && sortInfo.SortDirection.HasValue)
            {
                var expr = sortInfo.Property.GetUnaryExpression<SeedCompressed>();
                
                var propType = typeof (SeedCompressed).GetProperty(sortInfo.Property).PropertyType;
                //CRAP HERE, FUUU! (because I don't know how to cast LambdaExpression to Expression<T, TProperty> where T and TProperty are set dynamically.
                //Also, if you manage to find out more elegant solution - please provide it!)
                if (propType == typeof(string))
                {
                    var expr2 = expr as Expression<Func<SeedCompressed, string>>;
                    if (sortInfo.SortDirection == ListSortDirection.Ascending)
                        search = search.OrderBy(expr2);
                    else
                        search = search.OrderByDescending(expr2);
                }
                else if (propType == typeof(DateTime?))
                {
                    var expr2 = expr as Expression<Func<SeedCompressed, DateTime?>>;
                    if (sortInfo.SortDirection == ListSortDirection.Ascending)
                        search = search.OrderBy(expr2);
                    else
                        search = search.OrderByDescending(expr2);
                } else if (propType == typeof (double))
                {
                    var expr2 = expr as Expression<Func<SeedCompressed, double>>;
                    if (sortInfo.SortDirection == ListSortDirection.Ascending)
                        search = search.OrderBy(expr2);
                    else
                        search = search.OrderByDescending(expr2);
                }
            }

            return search.Take(100).ToList().Select(DecompressSeed).ToList();
        }

        public List<TrackerSeedsCountInfo> GetCounts()
        {
            return seeds.AsQueryable().GroupBy(x => x.TrackerName).Select(x => new TrackerSeedsCountInfo(x.Key, x.Count())).ToList();
        }

        public List<string> GetCategories(string filter = "")
        {
            filter = filter.Trim().ToLowerInvariant();
            var search = seeds.AsQueryable().GroupBy(x=>x.Category);
            if (!string.IsNullOrEmpty(filter))
                search = search.Where(x => x.Key.ToLowerInvariant().Contains(filter));
            return search.Select(x => x.Key).OrderBy(x=>x).ToList();
        } 
    }
}
