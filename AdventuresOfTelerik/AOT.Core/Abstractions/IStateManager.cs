using AOT.Common.Enums;

namespace AOT.Core.Abstractions
{
    internal interface IStateManager
    {
        void StartState(GameState state);
    }
}
