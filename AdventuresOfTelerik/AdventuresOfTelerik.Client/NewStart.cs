using AdventuresOfTelerik.Engine;
using Autofac;

namespace AdventuresOfTelerik.Client
{
    public class NewStart
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            var injectionConfig = new InjectConfigModule();

            builder.RegisterModule<InjectConfigModule>();

            var container = builder.Build();
            var engine = container.Resolve<IGameEngine>();

            engine.Start();
        }
    }
}
