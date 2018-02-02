using System;

namespace AdventuresOfTelerik.ConsoleLoggerMine
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
