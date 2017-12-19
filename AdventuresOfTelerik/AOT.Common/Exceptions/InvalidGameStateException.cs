using AOT.Common.Enums;
using AOT.Common.Exceptions.Base;

namespace AOT.Common.Exceptions
{
    public class InvalidGameStateException : CustomException
    {
        public InvalidGameStateException(GameState gameState) 
            : base($"Invalid state of game: {gameState.ToString()}")
        {
        }
    }
}
