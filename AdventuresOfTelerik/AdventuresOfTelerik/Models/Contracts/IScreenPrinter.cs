using AdventuresOfTelerik.ConsoleLoggerMine;

namespace AdventuresOfTelerik.Models
{
    public interface IScreenPrinter
    {
        IConsoleLogger Logger { get; set; }

        void PrintStartScreen();

        string PrintChooseHeroScreen();

        void PrintAfterChoiceScreen();
    }
}