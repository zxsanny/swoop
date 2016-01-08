using System.Configuration;
using Autofac;
using Machine.Fakes;
using Machine.Specifications;
using Swoop.Compressor;
using Swoop.MongoRepository;

namespace Swoop.Tests
{
    public class IntegrationTests<TestClass> : WithSubject<TestClass>
        where TestClass : class
    {
        protected static IContainer Container { get; set; }
        private Establish context = () =>
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new CompressorModule());
            builder.RegisterModule(new MongoRepositoryModule(ConfigurationManager.ConnectionStrings["swoop"].ConnectionString));
            Container = builder.Build();
        };

    }
}