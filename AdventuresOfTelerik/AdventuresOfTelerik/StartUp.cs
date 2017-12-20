using AdventuresOfTelerik.Engine;
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
            GameEngine.Instance.Start();
        }
    }
}
