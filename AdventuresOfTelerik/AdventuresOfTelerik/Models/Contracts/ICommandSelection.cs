using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Models
{
    public interface ICommandSelection
    {
        void ReadCommands(IHero hero, IMap map, IGameFactory factory,
            IConsoleLogger logger, IHeroPrinter heroprint, IFightMode mode,
            ICollisionDetector detect, IHeroCoordinates coord);
    }
}