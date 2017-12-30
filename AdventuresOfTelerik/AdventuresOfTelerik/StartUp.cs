using AdventuresOfTelerik.Engine;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AdventuresOfTelerik
{
    public static class StartUp
    {
        public static void Main()
        {
            Console.SetWindowSize(120, 26);
            GameEngine.Instance.Start();
        }
    }
}
