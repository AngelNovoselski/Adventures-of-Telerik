using System.Collections.Generic;

namespace AdventuresOfTelerik.Engine
{
    public interface ICommand
    {
        string Name { get; }

        List<string> Parameters { get; }
    }
}
