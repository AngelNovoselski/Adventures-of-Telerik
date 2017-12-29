using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public class NegativeArgumentException : ArgumentException
    {
        public NegativeArgumentException()
            : base()
        {
            Console.WriteLine("Be positive!!!");
        }

        public NegativeArgumentException(string message)
            : base(message)
        {
            Console.WriteLine("Be positive!!!");
        }
    }
}
