using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models.Enemies;
using AdventuresOfTelerik.Models.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public static class CommandSelection
    {
        private const string WelcomeScreen = "Hello Adventurer!\n(Warning: hit ENTER after every choice to please the gods of your fate!!!)";
        private const string InvalidClassInput = "Wrong Class! Choose Again!";
        private const string JourneyMessage = "Your journey begins now!";
        private const string StartMessage = "ENTER into your adventure!";
        private const string GameOverMessage = "GAME OVER!!!";
        private const string DeadGameMessage = "You did just die!";
        private const string DeadGameMessageFun = "Congratulations!!!";
        private const string MageSelected = "You are Telerik Mage!";
        private const string WarriorSelected = "You are Telerik Warrior!";
        private const string HunterSelected = "You are Telerik Hunter!";
        private const string DeadMonsterMessage = "You beat the monster!!";
        private const string ChooseHero = "Choose your hero type:\n  Type 1 for mage:\n  Type 2 for warrior:\n  Type 3 for hunter:";
        private const string EscapeMessage = "You escaped your nightmare!";
        private const string EscapeMessageFun = "For now!!!";
        private const string ClimbRockMessage = "You try to climb the giant rock. You fall down and hit your head! Lose 1 HP!";
        private const string ChooseMessage = "Choose where to go!";
        private const string EnterMessage = "Enter the number!";
        private const string LeftMessage = "You went left along the road!";
        private const string RightMessage = "You went to the right side of the road!";
        private const string UpMessage = "You went up to the hill!";
        private const string DownMessage = "You went down the road!";
        private const string WrongInputMessage = "Wrong Input";

        public static void ReadCommands(Hero.Hero hero, Map map, GameFactory factory)
        {
            bool happyend = false;
            string currentLine = "";
            string message = JourneyMessage;
            Enemy enemy;

            while (hero.Hp > 0 && !happyend)
            {
                Console.Clear();
                Console.BackgroundColor = (ConsoleColor)hero.HeroColor;
                Console.WriteLine(message);
                Console.ResetColor();
                Console.WriteLine(hero.ToString());
                var coord = new HeroCoordinates(hero);
                Console.WriteLine(coord.ToString());
                Console.WriteLine(ChooseMessage);
                Console.WriteLine(" 1 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map)));
                Console.WriteLine(" 2 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map)));
                Console.WriteLine(" 3 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map)));
                Console.WriteLine(" 4 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map)));
                Console.WriteLine(EnterMessage);
                currentLine = Console.ReadLine();

                switch (currentLine)
                {
                    case "1":
                        if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == 'x')
                        {
                            message = EscapeMessage;
                            break;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '@')
                        {
                            message = ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '2')
                        {
                            enemy = factory.CreateDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '3')
                        {
                            enemy = factory.CreateBossMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '4')
                        {
                            enemy = factory.CreateBossDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            if (hero is Mage && hero.SpecialEnergy < 100)
                            {
                                hero.SpecialEnergy += 20;
                            }
                            if (hero is Hunter)
                            {
                                hero.Weapon.Ammo += 1;
                                if (hero.SpecialEnergy < 100)
                                {
                                    hero.SpecialEnergy += 20;
                                }
                            }
                            hero.Move(1);
                            message = LeftMessage;
                        }
                        break;
                    case "2":
                        if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == 'x')
                        {
                            message = EscapeMessage;
                            break;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '@')
                        {
                            message = ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '2')
                        {
                            enemy = factory.CreateDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '3')
                        {
                            enemy = factory.CreateBossMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '4')
                        {
                            enemy = factory.CreateBossDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            if (hero is Mage && hero.SpecialEnergy < 100)
                            {
                                hero.SpecialEnergy += 20;
                            }
                            if (hero is Hunter)
                            {
                                hero.Weapon.Ammo += 1;
                                if (hero.SpecialEnergy < 100)
                                {
                                    hero.SpecialEnergy += 20;
                                }
                            }
                            hero.Move(2);
                            message = RightMessage;
                        }
                        break;
                    case "3":
                        if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == 'x')
                        {
                            message = EscapeMessage;
                            break;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '@')
                        {
                            message = ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '2')
                        {
                            enemy = factory.CreateDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '3')
                        {
                            enemy = factory.CreateBossMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '4')
                        {
                            enemy = factory.CreateBossDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            if (hero is Mage && hero.SpecialEnergy < 100)
                            {
                                hero.SpecialEnergy += 20;
                            }
                            if (hero is Hunter)
                            {
                                hero.Weapon.Ammo += 1;
                                if (hero.SpecialEnergy < 100)
                                {
                                    hero.SpecialEnergy += 20;
                                }
                            }
                            hero.Move(3);
                            message = UpMessage;
                        }
                        break;
                    case "4":
                        if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == 'x')
                        {
                            message = EscapeMessage;
                            happyend = true;
                            break;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '@')
                        {
                            message = ClimbRockMessage;
                            hero.Hp -= 1;
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '1')
                        {
                            enemy = factory.CreateMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '2')
                        {
                            enemy = factory.CreateDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '3')
                        {
                            enemy = factory.CreateBossMonster();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '4')
                        {
                            enemy = factory.CreateBossDragon();
                            FightMode.Fight(hero, enemy);
                            message = DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            if (hero is Mage && hero.SpecialEnergy < 100)
                            {
                                hero.SpecialEnergy += 20;
                            }
                            if (hero is Hunter)
                            {
                                hero.Weapon.Ammo += 1;
                                if (hero.SpecialEnergy < 100)
                                {
                                    hero.SpecialEnergy += 20;
                                }
                            }
                            hero.Move(4);
                            message = DownMessage;
                        }
                        break;
                    default:
                        message = WrongInputMessage;
                        break;
                }
            }

            Console.Clear();

            if (happyend)
            {
                Console.WriteLine(EscapeMessage);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(EscapeMessageFun);
            }
            else
            {
                Console.WriteLine(DeadGameMessage);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(DeadGameMessageFun);
            }

            Console.WriteLine(GameOverMessage);
        }
    }
}
