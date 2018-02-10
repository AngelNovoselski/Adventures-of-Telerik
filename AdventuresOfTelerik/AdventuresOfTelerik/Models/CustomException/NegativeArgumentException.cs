using AdventuresOfTelerik.ConsoleLoggerMine;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using System;

namespace AdventuresOfTelerik.Models
{
    public class NegativeArgumentException : ArgumentException
    {
        public NegativeArgumentException(IConsoleLogger logger)
            : base()
        {
            logger.Write(GlobalMessages.PositiveMessage);
        }

        public NegativeArgumentException(string message)
            : base(message)
        {
            Console.WriteLine(GlobalMessages.PositiveMessage);
        }
    }
}
