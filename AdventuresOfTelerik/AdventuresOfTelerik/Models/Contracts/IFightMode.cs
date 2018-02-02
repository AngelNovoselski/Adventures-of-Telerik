using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using System;

namespace AdventuresOfTelerik.Models
{
    public interface IFightMode
    {
        void Fight(IHero hero, IEnemy enemy, IConsoleLogger logger, IHeroPrinter heroPrint);

        void OnFightedMonster(object sender, EventArgs args);
    }
}