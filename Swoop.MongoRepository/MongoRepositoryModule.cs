using Autofac;
using Autofac.Core;
using MongoDB.Driver;
using Swoop.Common.Repositories;

namespace Swoop.MongoRepository
{
    public class MongoRepositoryModule : Module
    {
        private readonly string ConnectionString;

        public MongoRepositoryModule(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
          
            builder.Register(ctx =>
            {
                var client = new MongoClient(ConnectionString);
                return client.GetDatabase(new MongoUrlBuilder(ConnectionString).DatabaseName);
            }).Named<IMongoDatabase>("MongoDatabase").SingleInstance();

            builder.RegisterType<SeedsMongoRepository>().As<ISeedsRepository>().WithParameter(ResolvedParameter.ForNamed<IMongoDatabase>("MongoDatabase")).SingleInstance();
            builder.RegisterType<TrackerRepository>().As<ITrackerRepository>().WithParameter(ResolvedParameter.ForNamed<IMongoDatabase>("MongoDatabase")).SingleInstance();
        }
    }
}
