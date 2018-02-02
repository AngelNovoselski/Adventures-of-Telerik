using System;
using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Models
{
    public class CommandSelection : ICommandSelection
    {
        public void ReadCommands(IHero hero, IMap map, IGameFactory factory,
            IConsoleLogger logger, IHeroPrinter heroprint, IFightMode mode,
            ICollisionDetector detect, IHeroCoordinates coord)
        {
            bool happyend = false;
            string currentLine = "";
            string message = GlobalMessages.JourneyMessage;
            IEnemy enemy;

            while (hero.Hp > 0 && !happyend)
            {
                logger.Clear();
                Console.BackgroundColor = (ConsoleColor)hero.HeroColor;
                logger.Write(message);
                Console.ResetColor();
                logger.Write(hero.ToString());
                logger.Write(coord.ToString());
                logger.Write(GlobalMessages.ChooseMessage);
                logger.Write(" 1 = " + detect.GuideMessage(detect.CheckCollisions(hero.PositionX, hero.PositionY - 1, map)));
                logger.Write(" 2 = " + detect.GuideMessage(detect.CheckCollisions(hero.PositionX, hero.PositionY + 1, map)));
                logger.Write(" 3 = " + detect.GuideMessage(detect.CheckCollisions(hero.PositionX - 1, hero.PositionY, map)));
                logger.Write(" 4 = " + detect.GuideMessage(detect.CheckCollisions(hero.PositionX + 1, hero.PositionY, map)));
                logger.Write(GlobalMessages.EnterMessage);
                currentLine = logger.Read();

                switch (currentLine)
                {
                    case "1":
                        if (detect.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == 'x')
                        {
                            message = GlobalMessages.EscapeMessage;
                            break;
                        }
                        else if (detect.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '@')
                        {
                            message = GlobalMessages.ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (detect.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (detect.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(1);
                            message = GlobalMessages.LeftMessage;
                        }
                        break;
                    case "2":
                        if (detect.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == 'x')
                        {
                            message = GlobalMessages.EscapeMessage;
                            break;
                        }
                        else if (detect.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '@')
                        {
                            message = GlobalMessages.ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (detect.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (detect.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(2);
                            message = GlobalMessages.RightMessage;
                        }
                        break;
                    case "3":
                        if (detect.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == 'x')
                        {
                            message = GlobalMessages.EscapeMessage;
                            break;
                        }
                        else if (detect.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '@')
                        {
                            message = GlobalMessages.ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (detect.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (detect.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(3);
                            message = GlobalMessages.UpMessage;
                        }
                        break;
                    case "4":
                        if (detect.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == 'x')
                        {
                            message = GlobalMessages.EscapeMessage;
                            happyend = true;
                            break;
                        }
                        else if (detect.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '@')
                        {
                            message = GlobalMessages.ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (detect.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (detect.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            mode.Fight(hero, enemy, logger, heroprint);
                            message = GlobalMessages.DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(4);
                            message = GlobalMessages.DownMessage;
                        }
                        break;
                    default:
                        message = GlobalMessages.WrongInputMessage;
                        break;
                }
            }

            logger.Clear();

            if (happyend)
            {
                logger.Write(GlobalMessages.EscapeMessage);
                System.Threading.Thread.Sleep(1000);
                logger.Write(GlobalMessages.EscapeMessageFun);
            }
            else
            {
                logger.Write(GlobalMessages.DeadGameMessage);
                System.Threading.Thread.Sleep(1000);
                logger.Write(GlobalMessages.DeadGameMessageFun);
            }

            logger.Write(GlobalMessages.GameOverMessage);
        }
    }
}
