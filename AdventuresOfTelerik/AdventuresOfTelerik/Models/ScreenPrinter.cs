using System;
using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Models
{
    public class ScreenPrinter : IScreenPrinter
    {
        private IConsoleLogger logger;

        public ScreenPrinter(IConsoleLogger logger)
        {
            this.Logger = logger;
        }

        public IConsoleLogger Logger
        {
            get { return this.logger; }
            set { this.logger = value ?? throw new NullReferenceException(GlobalMessages.NullMessage); }
        }

        public void PrintStartScreen()
        {
            this.Logger.Write(GlobalMessages.WelcomeScreen);
            this.Logger.Write(GlobalMessages.ChooseHero);
        }

        public string PrintChooseHeroScreen()
        {
            string command = this.logger.Read();

            while (command != "1" && command != "2" && command != "3")
            {
                this.Logger.Clear();
                this.Logger.Write(GlobalMessages.InvalidClassInput);
                this.Logger.Write(GlobalMessages.ChooseHero);
                command = this.Logger.Read();
            }

            switch (command)
            {
                case "1":
                    this.Logger.Write(GlobalMessages.MageSelected);
                    return GlobalMessages.MageStringMessage;
                case "2":
                    this.Logger.Write(GlobalMessages.WarriorSelected);
                    return GlobalMessages.WarriorStringMessage;
                case "3":
                    this.Logger.Write(GlobalMessages.HunterSelected);
                    return GlobalMessages.HunterStringMessage;
                default:
                    this.Logger.Write(GlobalMessages.InvalidClassInput);
                    return GlobalMessages.NotValidMessage;
            }
        }

        public void PrintAfterChoiceScreen()
        {
            this.logger.Write(GlobalMessages.StartMessage);
            this.logger.ReadKey();
        }
    }
}
