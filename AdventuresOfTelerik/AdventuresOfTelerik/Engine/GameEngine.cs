using System;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly IGameFactory factory;
        private readonly IScreenPrinter printer;
        private readonly IHeroPrinter heroPrint;
        private readonly IFightMode fightMode;
        private readonly ICollisionDetector detect;
        private readonly ICommandSelection commandSelection;
        private readonly IMap map;
        private IHero hero;
        private IHeroCoordinates heroCord;

        public GameEngine(IGameFactory factory, IScreenPrinter printer, IHeroPrinter heroPrint,
                            IFightMode fightMode, ICollisionDetector detect, ICommandSelection commandSelection)
        {
            this.factory = factory ?? throw new NullReferenceException();
            this.printer = printer ?? throw new NullReferenceException();
            this.heroPrint = heroPrint ?? throw new NullReferenceException();
            this.fightMode = fightMode ?? throw new NullReferenceException();
            this.detect = detect ?? throw new NullReferenceException();
            this.commandSelection = commandSelection ?? throw new NullReferenceException();
            this.Factory.HeroFactory();
            this.map = this.Factory.CreateMap() ?? throw new NullReferenceException();
            Console.SetWindowSize(120, 26);
        }

        public IGameFactory Factory { get { return this.factory; } }
        public IScreenPrinter Printer { get { return this.printer; } }
        public IHeroPrinter HeroPrint { get { return this.heroPrint; } }
        public IFightMode FightMode { get { return this.fightMode; } }
        public ICollisionDetector Detect { get { return this.detect; } }
        public ICommandSelection CommandSelection { get { return this.commandSelection; } }
        public IMap Map { get { return this.map; } }
        public IHero Hero
        {
            get { return this.hero; }
            set { this.hero = value ?? throw new NullReferenceException(); }
        }
        public IHeroCoordinates HeroCord
        {
            get { return this.heroCord; }
            set { this.heroCord = value ?? throw new NullReferenceException(); }
        }

        public void Start()
        {
            this.Printer.PrintStartScreen();
            var heroType = this.Printer.PrintChooseHeroScreen();
            this.Printer.PrintAfterChoiceScreen();
            this.Hero = this.Factory.GetHeroBasedOnType(heroType);
            this.HeroCord = this.Factory.CreateHeroCoordinates(this.Hero);
            this.CommandSelection.ReadCommands(this.Hero, this.Map, this.Factory, this.Printer.Logger, this.HeroPrint, this.FightMode, this.Detect, this.HeroCord);
        }
    }
}
