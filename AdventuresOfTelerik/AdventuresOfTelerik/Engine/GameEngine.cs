using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.Enemies;
using AdventuresOfTelerik.Models.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventuresOfTelerik.Engine
{
    public sealed class GameEngine : IEngine
    {
        private const string JourneyMessage = "Your journey begins now!";
        private const string StartMessage = "ENTER into your adventure!";
        private const string GameOverMessage = "GAME OVER!!!";
        private const string DeadGameMessage = "You did just die!";
        private const string DeadGameMessageFun = "Congratulations!!!";
        public const string EscapeMessage = "You escaped your nightmare!";
        public const string EscapeMessageFun = "For now!!!";
        public const string ExitMessage = "You see the exit of the labyrinth!!!";
        public const string BossMonsterMessage = "The ground arround you trembles as the visious Xlliyu the spawn of Cthulhu appears before you!\n     It is time to prove you are worthy to protect this realm!";
        private const string DeadMonsterMessage = "You beat the monster!!";
        public const string MonsterMessage = "You see a dark silhouette! Weird that you cant see what it is even tought its midday.";
        public const string PathMessage = "There is a path! It looks safe but you have a feeling this may not be the case.";
        public const string ClimbRockMessage = "You try to climb the giant rock. You fall down and hit your head! Lose 1 HP!";
        public const string RockMessage = "There is a giant rock! If you dont want to get hurt you better not try anything funny like climbing it.";
        private const string WelcomeScreen = "Hello Adventurer!\n(Warning: hit ENTER after every choice to please the gods of your fate!!!)";
        private const string InvalidClassInput = "Wrong Class! Choose Again!";
        private const string MageSelected = "You are Telerik Mage!";
        private const string WarriorSelected = "You are Telerik Warrior!";
        private const string HunterSelected = "You are Telerik Hunter!";
        private const string ChooseHero = "Choose your hero type:\n  Type 1 for mage:\n  Type 2 for warrior:\n  Type 3 for hunter:";

        private static GameEngine SingleInstance;
        private Hero hero;
        private Map map;
        private Enemy enemy;
        private readonly GameFactory factory;
        private string heroType;
        private bool happyend;

        private GameEngine()
        {
            this.factory = new GameFactory();
            this.map = this.factory.CreateMap();
        }

        public static GameEngine Instance
        {
            get
            {
                if (SingleInstance == null)
                {
                    SingleInstance = new GameEngine();
                }

                return SingleInstance;
            }
        }

        public void Start()
        {
            this.PrintStartScreen();
            this.ReadCommands();
        }

        private void PrintStartScreen()
        {
            Console.WriteLine(WelcomeScreen);
            Console.WriteLine(ChooseHero);
            string command = Console.ReadLine();
            Console.WriteLine(this.ProcessStartScreen(command));
            Console.WriteLine(StartMessage);
            Console.ReadKey();
        }

        private string ProcessStartScreen(string command)
        {
            while (command != "1" && command != "2" && command != "3")
            {
                Console.Clear();
                Console.WriteLine(InvalidClassInput);
                Console.WriteLine(ChooseHero);
                command = Console.ReadLine();
            }

            switch (command)
            {
                case "1":
                    hero = this.factory.CreateMage();
                    return MageSelected;
                case "2":
                    hero = this.factory.CreateWarrior();
                    return WarriorSelected;
                case "3":
                    hero = this.factory.CreateHunter();
                    return HunterSelected;
                default:
                    return InvalidClassInput;
            }
        }

        private void ReadCommands()
        {
            string currentLine = "";
            string message = JourneyMessage;

            while (hero.Hp > 0 && !happyend)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                Console.WriteLine(hero.ToString());
                Console.WriteLine("Choose where to go!");
                Console.WriteLine(" 1 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map)));
                Console.WriteLine(" 2 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map)));
                Console.WriteLine(" 3 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map)));
                Console.WriteLine(" 4 = " + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map)));
                Console.WriteLine("Enter the number!");
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
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(1);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(1);
                            message = "You went left along the road!";
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
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(2);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(2);
                            message = "You went to the right side of the road!";
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
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(3);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(3);
                            message = "You went up to the hill!";
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
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '2')
                        {
                            enemy = factory.CreateBossMonster();
                            Fight();
                            message = DeadMonsterMessage;
                            hero.Move(4);
                            map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                        }
                        else
                        {
                            hero.Move(4);
                            message = "You went down the road!";
                        }
                        break;
                    default:
                        message = "Wrong Input";
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

        private void Fight()
        {
            var message = "You engage a " + enemy.GetType().Name + "!!!";
            heroType = hero.GetType().Name;

            if (heroType == "Hunter")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Energy:" + hero.Energy + ", " + "Bow Ammo:" + hero.Weapon.Ammo);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("Enter 1 to Shoot with your " + hero.Weapon.GetType().Name);
                    Console.WriteLine("Enter 2 to Run for your Life");
                    Console.WriteLine("Enter 3 for FocusShot");
                    Console.WriteLine("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            if (hero.Weapon.Ammo == 0)
                            {
                                Console.WriteLine($"No more ammo, try something else!");
                                break;
                            }
                            else
                            {
                                enemy.Hp -= hero.Weapon.Dmg;
                                if (hero.Weapon.Ammo > 0)
                                {
                                    hero.Weapon.Ammo -= 1;
                                }
                                Console.WriteLine($"The monster loses {hero.Weapon.Dmg} HP!");
                                break;
                            }
                        case "2":
                            hero.Hp -= 5;
                            Console.WriteLine($"It is too late to run!");
                            break;
                        case "3":
                            if (hero.Energy < 44)
                            {
                                Console.WriteLine($"Not enough energy for FocusShot!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                int score = hero.FocusShot();
                                enemy.Hp -= hero.Weapon.Dmg + score;
                                Console.WriteLine($"The monster loses {hero.Weapon.Dmg + score} HP!");
                                //hero.Weapon.Ammo -= 1;
                                break;
                            }
                        case "4":
                            enemy.Hp -= hero.WeaponSecond.Dmg;
                            Console.WriteLine($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"You lose {enemy.Dmg} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg;
                }
            }
            if (heroType == "Warrior")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Fury:" + hero.Fury);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("Enter 1 for hit with " + hero.Weapon.GetType().Name);
                    Console.WriteLine("Enter 2 to Run for your Life");
                    Console.WriteLine("Enter 3 for RageAnger");
                    Console.WriteLine("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            Console.WriteLine($"The monster loses {hero.Weapon.Dmg} HP!");
                            break;
                        case "2":
                            hero.Hp -= 5;
                            Console.WriteLine($"It is too late to run!");
                            break;
                        case "3":
                            if (hero.Fury < 40)
                            {
                                Console.WriteLine($"Not enough fury for RageAnger!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                int score = hero.RageAnger();
                                enemy.Hp -= hero.Weapon.Dmg + score;
                                Console.WriteLine($"The monster loses {hero.Weapon.Dmg + score} HP!");
                                break;
                            }
                        case "4":
                            enemy.Hp -= hero.WeaponSecond.Dmg;
                            Console.WriteLine($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"You lose {enemy.Dmg} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg;
                }
            }
            if (heroType == "Mage")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Mana:" + hero.Mana);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("Enter 1 for hit with " + hero.Weapon.GetType().Name);
                    Console.WriteLine("Enter 2 to Run for your Life");
                    Console.WriteLine("Enter 3 for CastSpell");
                    Console.WriteLine("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            Console.WriteLine($"The monster loses {hero.Weapon.Dmg} HP!");
                            break;
                        case "2":
                            hero.Hp -= 5;
                            Console.WriteLine($"It is too late to run!");
                            break;
                        case "3":
                            if (hero.Mana < 35)
                            {
                                Console.WriteLine($"Not enough mana for CastSpell!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                int score = hero.CastSpell();
                                enemy.Hp -= hero.Weapon.Dmg + score;
                                Console.WriteLine($"The monster loses {hero.Weapon.Dmg + score} HP!");
                                break;
                            }
                        case "4":
                            enemy.Hp -= hero.WeaponSecond.Dmg;
                            Console.WriteLine($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"You lose {enemy.Dmg} HP!");
                    System.Threading.Thread.Sleep(2000);
                    hero.Hp -= enemy.Dmg;
                }
            }
        }
    }
}
