using System.Text;
using AOT.Core.Abstractions;
using System;

namespace AOT.ConsoleClient.UI
{
    public class ConsoleRender : IRender
    {
        public ConsoleRender()
        {
            this.ConfigSettings();
        }

        private void ConfigSettings()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.SetBufferSize(90, 45);
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.SetWindowSize(90, 45);
            //Console.SetWindowPosition(90, 45);
            Console.CursorVisible = false;
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void PrintMsg(string msg)
        {
            Console.WriteLine(msg);
        }

        public void RenderScreen(StringBuilder screen)
        {
            this.ClearScreen();
            Console.WriteLine(screen.ToString());
        }
    }
}
