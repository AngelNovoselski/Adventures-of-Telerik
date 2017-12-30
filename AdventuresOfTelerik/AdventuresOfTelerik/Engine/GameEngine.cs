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
    public sealed class GameEngine : IGameEngine
    {
        private const string StartMessage = "ENTER into your adventure!";
        private const string WelcomeScreen = "Hello Adventurer!\n(Warning: hit ENTER after every choice to please the gods of your fate!!!)";
        private const string InvalidClassInput = "Wrong Class! Choose Again!";
        private const string MageSelected = "You are Telerik Mage!";
        private const string WarriorSelected = "You are Telerik Warrior!";
        private const string HunterSelected = "You are Telerik Hunter!";
        private const string EscapeMessage = "You escaped your nightmare!";
        private const string EscapeMessageFun = "For now!!!";
        private const string ClimbRockMessage = "You try to climb the giant rock. You fall down and hit your head! Lose 1 HP!";
        private const string ChooseHero = "Choose your hero type:\n  Type 1 for mage:\n  Type 2 for warrior:\n  Type 3 for hunter:";

        private static GameEngine SingleInstance;
        private readonly GameFactory factory;
        private Hero hero;
        private Map map;

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
            CommandSelection.ReadCommands(this.hero, this.map, this.factory);
        }

        private void PrintStartScreen()
        {
            Console.WriteLine(WelcomeScreen);
            Console.WriteLine(ChooseHero);
            string command = Console.ReadLine();
            Console.WriteLine(this.ChooseHeroScreen(command));
            Console.WriteLine(StartMessage);
            Console.ReadKey();
        }

        private string ChooseHeroScreen(string command)
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
    }
}
