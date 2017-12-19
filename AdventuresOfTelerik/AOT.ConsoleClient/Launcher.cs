using AOT.ConsoleClient.UI;
using AOT.Core;

namespace AOT.ConsoleClient
{
    public class Launcher
    {
        static void Main()
        {
            var render = new ConsoleRender();
            var inputReader = new ConsoleInputReader();
            Engine.Instance.Initialize(render, inputReader);
            Engine.Instance.Start();
        }
    }
}
