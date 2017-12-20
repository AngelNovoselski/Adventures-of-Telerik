using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
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
        //private const string CategoryCreated = "Category with name {0} was created!";
        //private const string CategoryDoesNotExist = "Category {0} does not exist!";
        //private const string ProductDoesNotExist = "Product {0} does not exist!";
        //private const string ProductAddedToCategory = "Product {0} added to category {1}!";
        //private const string ProductRemovedCategory = "Product {0} removed from category {1}!";
        //private const string ProductAlreadyExist = "Product with name {0} already exists!";
        //private const string ProductCreated = "Product with name {0} was created!";
        //private const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";
        //private const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        //private const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";
        //private const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";
        //private const string InvalidGenderType = "Invalid gender type!";
        //private const string InvalidUsageType = "Invalid usage type!";

        private static GameEngine SingleInstance;
        private Hero herrr;
        //private IWeapon weapon;
        private Map mappo;
        private IEnemy enem;
        private readonly GameFactory factory;

        private GameEngine()
        {
            this.factory = new GameFactory();
            mappo = this.factory.CreateMap();
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
            int type = int.Parse(Console.ReadLine());
            Console.WriteLine(ProcessStartScreen(type));
            Console.WriteLine("ENTER into your adventure!");
            Console.ReadKey();
        }

        private string ProcessStartScreen(int command)
        {
            while (command != 1 && command != 2 && command != 3)
            {
                Console.WriteLine("Wrong Class! Choose Again!");
                command = int.Parse(Console.ReadLine());
            }
            switch (command)
            {
                case 1:
                    herrr = this.factory.CreateMage();
                    herrr.Weapon = this.factory.CreateStaff();
                    return "You are Telerik Mage!";
                case 2:
                    herrr = this.factory.CreateWarrior();
                    herrr.Weapon = this.factory.CreateMace();
                    return "You are Telerik Warrior!";
                case 3:
                    herrr = this.factory.CreateHunter();
                    herrr.Weapon = this.factory.CreateBow();
                    return "You are Telerik Hunter!";
                default:
                    return "Wrong Class! Choose Again!";
            }
        }

        private void ReadCommands()
        {
            while (herrr.Hp > 0)
            {
               // Console.ReadLine();
                //var commands = new List<ICommand>();

                var currentLine = "0";
                var msg = "Your journey begins now!";
                //while (currentLine != 1 || currentLine != 2 || currentLine != 3 || currentLine != 4)
                while (herrr.Hp>0)
                {
                   
                
                    Console.Clear();
                    Console.WriteLine(msg);         
                    Console.WriteLine("Hero X:" + herrr.PositionX + " " + "Hero Y:" + herrr.PositionY);
                    Console.WriteLine("Hero Hp:" + herrr.Hp + " " + "Hero Energy:" + herrr.Energy);
                    Console.WriteLine("Hero Weapon:" + herrr.Weapon.ToString());
                    Console.WriteLine("Choose where to go!");
                    Console.WriteLine(" 1 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(herrr.PositionX, herrr.PositionY - 1, mappo)));
                    Console.WriteLine(" 2 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(herrr.PositionX, herrr.PositionY + 1, mappo)));
                    Console.WriteLine(" 3 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(herrr.PositionX - 1, herrr.PositionY , mappo)));
                    Console.WriteLine(" 4 = You see a" + CollisionDetector.GuideMessage(CollisionDetector.CheckCollisions(herrr.PositionX + 1, herrr.PositionY , mappo)));
                    Console.WriteLine("Enter the number!");
                    currentLine = Console.ReadLine();
                    
                    switch (currentLine)
                    {
                        case "1":
                            //CheckMap(mappo);
                            if (CollisionDetector.CheckCollisions(herrr.PositionX, herrr.PositionY - 1, mappo) == '@')
                            {
                                msg= "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(herrr.PositionX, herrr.PositionY - 1, mappo) == '1')
                            {
                                enem = factory.CreateMonster();
                                msg = "You engage a monster!";
                                while (herrr.Hp>0 && enem.Hp>0)
                                {
                                    Console.Clear();
                                    Console.WriteLine(msg);
                                    Console.WriteLine("Hero Hp:" + herrr.Hp + " " + "Hero Energy:" + herrr.Energy);
                                    Console.WriteLine("Enemy Hp:" + enem.Hp + " " + "Enemy Energy:" + enem.Energy);
                                    Console.WriteLine("enter 1 for hit");
                                    Console.WriteLine("enter 2 to RUN");
                                    var a = Console.ReadLine();
                                    switch (a)
                                    {
                                        case "1":
                                            enem.Hp -= herrr.Weapon.Dmg;
                                            herrr.Hp -= enem.Dmg;
                                            break;
                                        case "2":
                                            herrr.Hp = 0;
                                            return;
                                        default:
                                            break;
                                    }
                                    
                                }
                                msg = "you beat the monster!";
                                herrr.Move(1);
                                mappo.FirstMap[herrr.PositionX, herrr.PositionY] = '-';
                            }
                            else
                            {
                                herrr.Move(1);
                                msg = "You went left!";
                            }
                            break;
                        case "2":
                            if (CollisionDetector.CheckCollisions(herrr.PositionX, herrr.PositionY + 1, mappo) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(herrr.PositionX, herrr.PositionY + 1, mappo) == '1')
                            {
                                enem = factory.CreateMonster();
                                msg = "You engage a monster!";
                                while (herrr.Hp > 0 && enem.Hp > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine(msg);
                                    Console.WriteLine("Hero Hp:" + herrr.Hp + " " + "Hero Energy:" + herrr.Energy);
                                    Console.WriteLine("Enemy Hp:" + enem.Hp + " " + "Enemy Energy:" + enem.Energy);
                                    Console.WriteLine("enter 1 for hit");
                                    Console.WriteLine("enter 2 to RUN");
                                    var a = Console.ReadLine();
                                    switch (a)
                                    {
                                        case "1":
                                            enem.Hp -= herrr.Weapon.Dmg;
                                            herrr.Hp -= enem.Dmg;
                                            break;
                                        case "2":
                                            herrr.Hp = 0;
                                            break;
                                        default:
                                            break;
                                    }
                                    
                                }
                                msg = "you beat the monster!";
                                herrr.Move(2);
                                mappo.FirstMap[herrr.PositionX, herrr.PositionY] = '-';
                            }
                            else
                            {
                                herrr.Move(2);
                                msg = "You went right!";
                            }
                            break;
                        case "3":
                            if (CollisionDetector.CheckCollisions(herrr.PositionX - 1, herrr.PositionY, mappo) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(herrr.PositionX-1, herrr.PositionY , mappo) == '1')
                            {
                                enem = factory.CreateMonster();
                                msg = "You engage a monster!";
                                while (herrr.Hp > 0 && enem.Hp > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine(msg);
                                    Console.WriteLine("Hero Hp:" + herrr.Hp + " " + "Hero Energy:" + herrr.Energy);
                                    Console.WriteLine("Enemy Hp:" + enem.Hp + " " + "Enemy Energy:" + enem.Energy);
                                    Console.WriteLine("enter 1 for hit");
                                    Console.WriteLine("enter 2 to RUN");
                                    var a = Console.ReadLine();
                                    switch (a)
                                    {
                                        case "1":
                                            enem.Hp -= herrr.Weapon.Dmg;
                                            herrr.Hp -= enem.Dmg;
                                            break;
                                        case "2":
                                            herrr.Hp = 0;
                                            break;
                                        default:
                                            break;
                                    }
                                   
                                }
                                msg = "you beat the monster!";
                                herrr.Move(3);
                                mappo.FirstMap[herrr.PositionX, herrr.PositionY] = '-';
                            }
                            else
                            {
                                herrr.Move(3);
                                msg = "You went up!";
                            }
                            break;
                        case "4":
                            if (CollisionDetector.CheckCollisions(herrr.PositionX + 1, herrr.PositionY, mappo) == '@')
                            {
                                msg = "Tree here!";
                            }
                            else if (CollisionDetector.CheckCollisions(herrr.PositionX+1, herrr.PositionY, mappo) == '1')
                            {
                                enem = factory.CreateMonster();
                                msg = "You engage a monster!";
                                while (herrr.Hp > 0 && enem.Hp > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine(msg);
                                    Console.WriteLine("Hero Hp:" + herrr.Hp + " " + "Hero Energy:" + herrr.Energy);
                                    Console.WriteLine("Enemy Hp:" + enem.Hp + " " + "Enemy Energy:" + enem.Energy);
                                    Console.WriteLine("enter 1 for hit");
                                    Console.WriteLine("enter 2 to RUN");
                                    var a = Console.ReadLine();
                                    switch (a)
                                    {
                                        case "1":
                                            enem.Hp -= herrr.Weapon.Dmg;
                                            herrr.Hp -= enem.Dmg;
                                            break;
                                        case "2":
                                            herrr.Hp = 0;
                                            break;
                                        default:
                                            break;
                                    }
                                    
                                }
                                msg = "you beat the monster!";
                                herrr.Move(4);
                                mappo.FirstMap[herrr.PositionX , herrr.PositionY] = '-';
                            }
                            else
                            {
                                herrr.Move(4);
                                msg = "You went down!";
                            }
                            break;
                        default:
                            msg = "Wrong Input";
                            break;
                    }
                   
                    
                }
            }
            Console.WriteLine("You did just die!\r\nGAME OVER!!!");
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

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            Console.Write(output.ToString());
        }

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
