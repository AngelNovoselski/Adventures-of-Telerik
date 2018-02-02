using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;

namespace AdventuresOfTelerik.Models.MessagesForPrinting
{
    public interface IHeroPrinter
    {
        void PrintWarriorFightMesssage(IHero hero, IEnemy enemy, IConsoleLogger logger);

        void PrintMageFightMesssage(IHero hero, IEnemy enemy, IConsoleLogger logger);

        void PrintHunterFightMesssage(IHero hero, IEnemy enemy, IConsoleLogger logger);
    }
}