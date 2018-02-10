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
        private IMap map;
        private IHero hero;
        private IHeroCoordinates heroCord;
        private string heroType;

        public GameEngine(IGameFactory factory, IScreenPrinter printer, IHeroPrinter heroPrint,
                            IFightMode fightMode, ICollisionDetector detect, ICommandSelection commandSelection)
        {
            this.factory = factory ?? throw new ArgumentNullException ();
            this.printer = printer ?? throw new ArgumentNullException ();
            this.heroPrint = heroPrint ?? throw new ArgumentNullException ();
            this.fightMode = fightMode ?? throw new ArgumentNullException ();
            this.detect = detect ?? throw new ArgumentNullException ();
            this.commandSelection = commandSelection ?? throw new ArgumentNullException ();
            this.Factory.HeroFactory();
            this.printer.Logger.SetSize();
        }

        public IGameFactory Factory { get { return this.factory; } }
        public IScreenPrinter Printer { get { return this.printer; } }
        public IHeroPrinter HeroPrint { get { return this.heroPrint; } }
        public IFightMode FightMode { get { return this.fightMode; } }
        public ICollisionDetector Detect { get { return this.detect; } }
        public ICommandSelection CommandSelection { get { return this.commandSelection; } }

        public IMap Map
        {
            get { return this.map; }
            set { this.map = value ?? throw new ArgumentNullException (); }
        }

        public IHero Hero
        {
            get { return this.hero; }
            set { this.hero = value ?? throw new ArgumentNullException (); }
        }

        public IHeroCoordinates HeroCord
        {
            get { return this.heroCord; }
            set { this.heroCord = value ?? throw new ArgumentNullException (); }
        }

        public void Start()
        {
            this.Map = this.Factory.CreateMap();
            this.Printer.PrintStartScreen();
            this.heroType = this.Printer.PrintChooseHeroScreen();
            this.Printer.PrintAfterChoiceScreen();
            this.Hero = this.Factory.GetHeroBasedOnType(heroType);
            this.HeroCord = this.Factory.CreateHeroCoordinates(this.Hero);
            this.CommandSelection.ReadCommands(this.Hero, this.Map, this.Factory, this.Printer.Logger, this.HeroPrint, this.FightMode, this.Detect, this.HeroCord);
        }
    }
}
