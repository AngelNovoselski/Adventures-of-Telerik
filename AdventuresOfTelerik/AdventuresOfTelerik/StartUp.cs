using AdventuresOfTelerik.Engine;
using AdventuresOfTelerik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik
{
    public static class StartUp
    {
        static void Main()
        {
            Console.SetWindowSize(120, 26);
            GameEngine.Instance.Start();
        }
    }
}
