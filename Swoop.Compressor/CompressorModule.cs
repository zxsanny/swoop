using Autofac;

namespace Swoop.Compressor
{
    public class CompressorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<NoemaxCompressor>().As<ICompressor>().SingleInstance();
        }
    }
}
