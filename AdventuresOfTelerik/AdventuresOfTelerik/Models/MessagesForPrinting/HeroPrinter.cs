using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;

namespace AdventuresOfTelerik.Models.MessagesForPrinting
{
    public class HeroPrinter : IHeroPrinter
    {
        public void PrintWarriorFightMesssage(IHero hero, IEnemy enemy, IConsoleLogger logger)
        {
            var message = "You engage a " + enemy.GetType().Name + "!!!";
            while (hero.Hp > 0 && enemy.Hp > 0)
            {
                logger.Clear();
                logger.Write(message);
                logger.Write("Hero Hp:" + hero.Hp + ", " + "Hero Fury:" + hero.SpecialEnergy);
                logger.Write("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                logger.Write("Enter 1 for hit with " + hero.Weapon.GetType().Name);
                logger.Write("Enter 2 to Run for your Life");
                logger.Write("Enter 3 for RageAnger");
                logger.Write("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);

                var a = logger.Read();
                switch (a)
                {
                    case "1":
                        enemy.Hp -= hero.Weapon.Dmg;
                        logger.Write($"The monster loses {hero.Weapon.Dmg} HP!");
                        break;
                    case "2":
                        hero.Hp -= 5;
                        logger.Write($"It is too late to run!");
                        break;
                    case "3":
                        if (hero.SpecialEnergy < 40)
                        {
                            logger.Write($"Not enough fury for RageAnger!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            int score = hero.SpecialAttack();
                            enemy.Hp -= hero.Weapon.Dmg + score;
                            logger.Write($"The monster loses {hero.Weapon.Dmg + score} HP!");
                            break;
                        }
                    case "4":
                        enemy.Hp -= hero.WeaponSecond.Dmg;
                        logger.Write($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                        break;
                    default:
                        break;
                }

                logger.Write("WAIT FOR ENEMY TURN");
                System.Threading.Thread.Sleep(1000);

                if (enemy.Energy < 5)
                {
                    logger.Write($"You lose {enemy.Dmg} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg;
                }
                else
                {
                    int score = enemy.Roar();
                    logger.Write($"The Monster Roars!");
                    logger.Write($"You lose {enemy.Dmg + score} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg + score;
                }
            }
        }

        public void PrintMageFightMesssage(IHero hero, IEnemy enemy, IConsoleLogger logger)
        {
            var message = "You engage a " + enemy.GetType().Name + "!!!";
            while (hero.Hp > 0 && enemy.Hp > 0)
            {
                logger.Clear();
                logger.Write(message);
                logger.Write("Hero Hp:" + hero.Hp + ", " + "Hero Mana:" + hero.SpecialEnergy);
                logger.Write("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                logger.Write("Enter 1 for hit with " + hero.Weapon.GetType().Name);
                logger.Write("Enter 2 to Run for your Life");
                logger.Write("Enter 3 for CastSpell");
                logger.Write("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);

                var a = logger.Read();
                switch (a)
                {
                    case "1":
                        enemy.Hp -= hero.Weapon.Dmg;
                        logger.Write($"The monster loses {hero.Weapon.Dmg} HP!");
                        break;
                    case "2":
                        hero.Hp -= 5;
                        logger.Write($"It is too late to run!");
                        break;
                    case "3":
                        if (hero.SpecialEnergy < 35)
                        {
                            logger.Write($"Not enough mana for CastSpell!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            int score = hero.SpecialAttack();
                            enemy.Hp -= hero.Weapon.Dmg + score;
                            logger.Write($"The monster loses {hero.Weapon.Dmg + score} HP!");
                            break;
                        }
                    case "4":
                        enemy.Hp -= hero.WeaponSecond.Dmg;
                        logger.Write($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                        break;
                    default:
                        break;
                }
                logger.Write("WAIT FOR ENEMY TURN");
                System.Threading.Thread.Sleep(1000);

                if (enemy.Energy < 5)
                {
                    logger.Write($"You lose {enemy.Dmg} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg;
                }
                else
                {
                    int score = enemy.Roar();
                    logger.Write($"The Monster Roars!");
                    logger.Write($"You lose {enemy.Dmg + score} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg + score;
                }
            }
        }

        public void PrintHunterFightMesssage(IHero hero, IEnemy enemy, IConsoleLogger logger)
        {
            var message = "You engage a " + enemy.GetType().Name + "!!!";
            var ammo = 5;
            while (hero.Hp > 0 && enemy.Hp > 0)
            {
                logger.Clear();
                logger.Write(message);
                logger.Write("Hero Hp:" + hero.Hp + ", " + "Hero Energy:" + hero.SpecialEnergy + ", " + "Bow Ammo:" + ammo);
                logger.Write("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                logger.Write("Enter 1 to Shoot with your " + hero.Weapon.GetType().Name);
                logger.Write("Enter 2 to Run for your Life");
                logger.Write("Enter 3 for FocusShot");
                logger.Write("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);

                var a = logger.Read();
                switch (a)
                {
                    case "1":
                        if (ammo == 0)
                        {
                            logger.Write($"No more ammo, try something else!");
                            break;
                        }
                        else
                        {
                            enemy.Hp -= hero.Weapon.Dmg;
                            if (ammo > 0)
                            {
                                ammo -= 1;
                            }
                            logger.Write($"The monster loses {hero.Weapon.Dmg} HP!");
                            break;
                        }
                    case "2":
                        hero.Hp -= 5;
                        logger.Write($"It is too late to run!");
                        break;
                    case "3":
                        if (hero.SpecialEnergy < 44)
                        {
                            logger.Write($"Not enough energy for FocusShot!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            int score = hero.SpecialAttack();
                            enemy.Hp -= hero.Weapon.Dmg + score;
                            logger.Write($"The monster loses {hero.Weapon.Dmg + score} HP!");
                            break;
                        }
                    case "4":
                        enemy.Hp -= hero.WeaponSecond.Dmg;
                        logger.Write($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                        break;
                    default:
                        break;
                }
                logger.Write("WAIT FOR ENEMY TURN");
                System.Threading.Thread.Sleep(1000);

                if (enemy.Energy < 5)
                {
                    logger.Write($"You lose {enemy.Dmg} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg;
                }
                else
                {
                    int score = enemy.Roar();
                    logger.Write($"The Monster Roars!");
                    logger.Write($"You lose {enemy.Dmg + score} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg + score;
                }
            }
        }
    }
}
