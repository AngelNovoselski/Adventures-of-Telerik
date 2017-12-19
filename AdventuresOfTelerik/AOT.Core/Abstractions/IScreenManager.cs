using System.Text;

namespace AOT.Core.Abstractions
{
    internal interface IScreenManager
    {
        StringBuilder GenerateMenuScreen();

        StringBuilder GenerateNewGameScreen();

        StringBuilder GenerateLoadGameScreen();

        StringBuilder GenerateSettingsScreen();

        StringBuilder GenerateCreditsScreen();

        StringBuilder GenerateExitScreen();
    }
}
