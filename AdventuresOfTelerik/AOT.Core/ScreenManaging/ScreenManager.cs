using System.Text;
using AOT.Core.Abstractions;
using System;

namespace AOT.Core.ScreenManaging
{
    internal class ScreenManager : IScreenManager
    {
        public StringBuilder GenerateCreditsScreen()
        {
            throw new System.NotImplementedException();
        }

        public StringBuilder GenerateExitScreen()
        {
            throw new System.NotImplementedException();
        }

        public StringBuilder GenerateLoadGameScreen()
        {
            throw new System.NotImplementedException();
        }

        public StringBuilder GenerateMenuScreen()
        {
            StringBuilder screen = new StringBuilder();

            screen.AppendLine(
                "Enter number to make your choice:" + Environment.NewLine + Environment.NewLine +
                "1. New Game" + Environment.NewLine + Environment.NewLine +
                "2. Load Game" + Environment.NewLine + Environment.NewLine +
                "3. Credits");

            return screen;
        }

        public StringBuilder GenerateNewGameScreen()
        {
            throw new System.NotImplementedException();
        }

        public StringBuilder GenerateSettingsScreen()
        {
            throw new System.NotImplementedException();
        }
    }
}
