using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Engine;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.Enemies;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using Autofac;
using System.Reflection;

namespace AdventuresOfTelerik.Client
{
    public class InjectConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IGameEngine)))
            //    .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<GameFactory>().As<IGameFactory>().SingleInstance();
            builder.RegisterType<ScreenPrinter>().As<IScreenPrinter>().SingleInstance();
            builder.RegisterType<HeroPrinter>().As<IHeroPrinter>().SingleInstance();
            builder.RegisterType<FightMode>().As<IFightMode>().SingleInstance();
            builder.RegisterType<CollisionDetector>().As<ICollisionDetector>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<IConsoleLogger>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>().SingleInstance();
            builder.RegisterType<CommandSelection>().As<ICommandSelection>().SingleInstance();

            //builder.RegisterType<Map>().Named<IMap>("Map");

            builder.RegisterType<GameEngine>().As<IGameEngine>().SingleInstance();
        }
    }
}
