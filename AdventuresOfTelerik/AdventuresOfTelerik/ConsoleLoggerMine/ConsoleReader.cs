using System;

namespace AdventuresOfTelerik.ConsoleLoggerMine
{
    public class ConsoleReader : IConsoleReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}
