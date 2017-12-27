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
        //private const string InvalidCommand = "Invalid command name: {0}!";
        //private const string CategoryExists = "Category with name {0} already exists!";

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
            map = this.factory.CreateMap();
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
            //var hero = this.factory.CreateHunter();
            //Console.WriteLine(hero.Weapon.Ammo); 
            PrintScreen();
            this.ReadCommands();
            //var commandResult = this.ProcessCommands(commands);
            //this.PrintReports(commandResult);
        }

        private void PrintScreen()
        {
            Console.WriteLine("Choose hero type:");
            Console.WriteLine("  Type 1 for mage:");
            Console.WriteLine("  Type 2 for warrior:");
            Console.WriteLine("  Type 3 for hunter:");
            string type = Console.ReadLine();
            Console.WriteLine(ProcessStartScreen(type));
            Console.WriteLine("ENTER into your adventure!");
            Console.ReadKey();
        }

        private string ProcessStartScreen(string command)
        {
            while (command != "1" && command != "2" && command != "3")
            {
                Console.Clear();
                Console.WriteLine("Wrong Class! Choose Again!");
                Console.WriteLine("Choose hero type:");
                Console.WriteLine("  Type 1 for mage:");
                Console.WriteLine("  Type 2 for warrior:");
                Console.WriteLine("  Type 3 for hunter:");
                command = Console.ReadLine();
            }

            switch (command)
            {
                case "1":
                    hero = this.factory.CreateMage();
                    heroType = "mage";
                    return "You are Telerik Mage!";
                case "2":
                    hero = this.factory.CreateWarrior();
                    heroType = "warrior";
                    return "You are Telerik Warrior!";
                case "3":
                    hero = this.factory.CreateHunter();
                    heroType = "hunter";
                    return "You are Telerik Hunter!";
                default:
                    return "Wrong Class! Choose Again!";
            }
        }

        private void ReadCommands()
        {
            while (hero.Hp > 0)
            {
                // Console.ReadLine();
                //var commands = new List<ICommand>();

                var currentLine = "0";
                var msg = "Your journey begins now!";

                //while (currentLine != 1 || currentLine != 2 || currentLine != 3 || currentLine != 4)
                while (hero.Hp > 0 && !happyend)
                {
                    Console.Clear();
                    Console.WriteLine(msg);
                    Console.WriteLine("Hero X:" + hero.PositionX + " " + "Hero Y:" + hero.PositionY);
                    Console.WriteLine("Hero Hp:" + hero.Hp);// + " " + "Hero Energy:" + hero.Energy);
                    Console.WriteLine("Hero Weapon:" + hero.Weapon.ToString());
                    Console.WriteLine("Choose where to go!");
                    Console.WriteLine(" 1 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map)));
                    Console.WriteLine(" 2 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map)));
                    Console.WriteLine(" 3 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map)));
                    Console.WriteLine(" 4 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map)));
                    Console.WriteLine("Enter the number!");
                    currentLine = Console.ReadLine();

                    switch (currentLine)
                    {
                        case "1":
                            if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == 'x')
                            {
                                msg = "You escaped your nightmare!";
                                break;
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY - 1, map) == '1')
                            {
                                enemy = factory.CreateMonster();
                                msg = "You engage a monster!";
                                msg = Fight(msg, heroType);
                                hero.Move(1);
                                map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                            }
                            else
                            {
                                hero.Move(1);
                                msg = "You went left!";
                            }
                            break;
                        case "2":
                            if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == 'x')
                            {
                                msg = "You escaped your nightmare!";
                                break;
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX, hero.PositionY + 1, map) == '1')
                            {
                                enemy = factory.CreateMonster();
                                msg = "You engage a monster!";
                                msg = Fight(msg, heroType);
                                hero.Move(2);
                                map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                            }
                            else
                            {
                                hero.Move(2);
                                msg = "You went right!";
                            }
                            break;
                        case "3":
                            if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == 'x')
                            {
                                msg = "You escaped your nightmare!";
                                break;
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX - 1, hero.PositionY, map) == '1')
                            {
                                enemy = factory.CreateMonster();
                                msg = "You engage a monster!";
                                msg = Fight(msg, heroType);
                                hero.Move(3);
                                map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                            }
                            else
                            {
                                hero.Move(3);
                                msg = "You went up!";
                            }
                            break;
                        case "4":
                            if (CollisionDetector.CheckCollisions(hero.PositionX+1, hero.PositionY, map) == 'x')
                            {
                                msg = "You escaped your nightmare!";
                                happyend = true;
                                break;
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(hero.PositionX + 1, hero.PositionY, map) == '1')
                            {
                                enemy = factory.CreateMonster();
                                msg = "You engage a monster!";
                                msg = Fight(msg, heroType);
                                hero.Move(4);
                                map.FirstMap[hero.PositionX, hero.PositionY] = '-';
                            }
                            else
                            {
                                hero.Move(4);
                                msg = "You went down!";
                            }
                            break;
                        default:
                            msg = "Wrong Input";
                            break;
                    }

                    if (happyend)
                    {
                        Console.Clear();
                        Console.WriteLine(msg);
                    }
                }
            }
            Console.WriteLine("You did just die!\r\nGAME OVER!!!");
        }

        private string Fight(string message, string heroType)
        {
            enemy = factory.CreateMonster();
            message = "You engage a monster!";
            if (heroType == "hunter")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Energy:" + hero.Energy);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("enter 1 to shoot with your " + hero.Weapon.GetType().Name);
                    Console.WriteLine("enter 2 to RUN for your life");
                    Console.WriteLine("enter 3 for FocusShot");
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            hero.Weapon.Ammo -= 1;
                            break;
                        case "2":
                            hero.Hp = 0;
                            break;
                        case "3":
                            enemy.Hp -= hero.Weapon.Dmg + hero.FocusShot();
                            hero.Weapon.Ammo -= 1;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    hero.Hp -= enemy.Dmg;
                }
            }
            if (heroType == "warrior")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Fury:" + hero.Fury);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("enter 1 for hit with " + hero.Weapon.GetType().Name);
                    Console.WriteLine("enter 2 to RUN for your life");
                    Console.WriteLine("enter 3 for RageAnger");
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            break;
                        case "2":
                            hero.Hp = 0;
                            break;
                        case "3":
                            enemy.Hp -= hero.Weapon.Dmg + hero.RageAnger();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    hero.Hp -= enemy.Dmg;
                }
            }
            if (heroType == "mage")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Mana:" + hero.Mana);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("enter 1 for hit with " + hero.Weapon.GetType().Name);
                    Console.WriteLine("enter 2 to RUN for your life");
                    Console.WriteLine("enter 3 for CastSpell");
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            break;
                        case "2":
                            hero.Hp = 0;
                            break;
                        case "3":
                            enemy.Hp -= hero.Weapon.Dmg + hero.CastSpell();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    hero.Hp -= enemy.Dmg;
                }
            }
            return message = "you beat the monster!";
        }

        //private IList<string> ProcessCommands(IList<ICommand> commands)
        //{
        //    var reports = new List<string>();

        //    foreach (var command in commands)
        //    {
        //        try
        //        {
        //            //var report = this.ProcessSingleCommand(command);
        //            //reports.Add(report);
        //        }
        //        catch (Exception ex)
        //        {
        //            reports.Add(ex.Message);
        //        }
        //    }

        //    return reports;
        //}

        //private void PrintReports(IList<string> reports)
        //{
        //    var output = new StringBuilder();

        //    foreach (var report in reports)
        //    {
        //        output.AppendLine(report);
        //    }

        //    Console.Write(output.ToString());
        //}

        //private string CreateCategory(string categoryName)
        //{
        //    if (this.categories.ContainsKey(categoryName))
        //    {
        //        return string.Format(CategoryExists, categoryName);
        //    }

        //    var category = this.factory.CreateCategory(categoryName);
        //    this.categories.Add(categoryName, category);

        //    return string.Format(CategoryCreated, categoryName);
        //}

        //private string AddToCategory(string categoryNameToAdd, string productToAdd)
        //{
        //    if (!this.categories.ContainsKey(categoryNameToAdd))
        //    {
        //        return string.Format(CategoryDoesNotExist, categoryNameToAdd);
        //    }

        //    if (!this.products.ContainsKey(productToAdd))
        //    {
        //        return string.Format(ProductDoesNotExist, productToAdd);
        //    }

        //    var category = this.categories[categoryNameToAdd];
        //    var product = this.products[productToAdd];

        //    category.AddProduct(product);

        //    return string.Format(ProductAddedToCategory, productToAdd, categoryNameToAdd);
        //}

        //private string RemoveCategory(string categoryNameToAdd, string productToRemove)
        //{
        //    if (!this.categories.ContainsKey(categoryNameToAdd))
        //    {
        //        return string.Format(CategoryDoesNotExist, categoryNameToAdd);
        //    }

        //    if (!this.products.ContainsKey(productToRemove))
        //    {
        //        return string.Format(ProductDoesNotExist, productToRemove);
        //    }

        //    var category = this.categories[categoryNameToAdd];
        //    var product = this.products[productToRemove];

        //    category.RemoveProduct(product);

        //    return string.Format(ProductRemovedCategory, productToRemove, categoryNameToAdd);
        //}

        //private string ShowCategory(string categoryToShow)
        //{
        //    if (!this.categories.ContainsKey(categoryToShow))
        //    {
        //        return string.Format(CategoryDoesNotExist, categoryToShow);
        //    }

        //    var category = this.categories[categoryToShow];

        //    return category.Print();
        //}

        //private string CreateProduct(string name, string brand, decimal price, string gender)
        //{
        //    if (this.products.ContainsKey(name))
        //    {
        //        return string.Format(ProductAlreadyExist, name);
        //    }

        //    var shampoo = this.factory.CreateProduct(name, brand, price, gender);
        //    this.products.Add(name, shampoo);

        //    return string.Format(ProductCreated, name);
        //}

        //private string AddToShoppingCart(string productName)
        //{
        //    if (!this.products.ContainsKey(productName))
        //    {
        //        return string.Format(ProductDoesNotExist, productName);
        //    }

        //    var product = this.products[productName];
        //    this.shoppingCart.AddProduct(product);

        //    return string.Format(ProductAddedToShoppingCart, productName);
        //}

        //private string RemoveFromShoppingCart(string productName)
        //{
        //    if (!this.products.ContainsKey(productName))
        //    {
        //        return string.Format(ProductDoesNotExist, productName);
        //    }

        //    var product = this.products[productName];

        //    if (!this.shoppingCart.ContainsProduct(product))
        //    {
        //        return string.Format(ProductDoesNotExistInShoppingCart, productName);
        //    }

        //    this.shoppingCart.RemoveProduct(product);

        //    return string.Format(ProductRemovedFromShoppingCart, productName);
        //}
    }
}
