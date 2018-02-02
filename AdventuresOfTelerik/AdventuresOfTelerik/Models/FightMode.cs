using System;
using System.Media;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using AdventuresOfTelerik.ConsoleLoggerMine;

namespace AdventuresOfTelerik.Models
{
    public class FightMode : IFightMode
    {
        public void Fight(IHero hero, IEnemy enemy, IConsoleLogger logger, IHeroPrinter heroPrint)
        {
            hero.FightMonster += new EventHandler(OnFightedMonster);
            hero.OnFightMonster();

            var message = "You engage a " + enemy.GetType().Name + "!!!";
            var heroType = hero.GetType().Name;

            if (heroType == "Hunter")
            {
                heroPrint.PrintHunterFightMesssage(hero, enemy, logger);
            }
            else if (heroType == "Warrior")
            {
                heroPrint.PrintWarriorFightMesssage(hero, enemy, logger);
            }
            else if (heroType == "Mage")
            {
                heroPrint.PrintMageFightMesssage(hero, enemy, logger);
            }
        }

        public void OnFightedMonster(object sender, EventArgs args)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"..\..\..\monster2.wav");
            simpleSound.Play();
        }
    }
}
