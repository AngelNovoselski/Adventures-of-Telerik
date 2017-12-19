using AOT.Core.Abstractions;
using System;

namespace AOT.ConsoleClient.UI
{
    public class ConsoleInputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string ReadKey()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            if (keyPressed.Key == ConsoleKey.LeftArrow)
            {
                return "moveLeft";
            }
            else if (keyPressed.Key == ConsoleKey.RightArrow)
            {
                return "moveRight";
            }
            else if(keyPressed.Key == ConsoleKey.DownArrow)
            {
                return "moveDown";
            }
            else if(keyPressed.Key == ConsoleKey.UpArrow)
            {
                return "moveUp";
            }
            else if(keyPressed.Key == ConsoleKey.Escape)
            {
                return "exit";
            }
            else if(keyPressed.Key == ConsoleKey.Enter)
            {
                return "skip";
            }
            else if(keyPressed.Key == ConsoleKey.S)
            {
                return "save";
            }
            else if(keyPressed.Key == ConsoleKey.I)
            {
                return "inventory";
            }
            else if(keyPressed.Key == ConsoleKey.D)
            {
                return "description";
            }

            return null;
        }
    }
}
