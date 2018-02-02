using AdventuresOfTelerik.Contracts;

namespace AdventuresOfTelerik.Models
{
    public interface ICollisionDetector
    {
        char CheckCollisions(int positionX, int positionY, IMap map);

        string GuideMessage(char a);
    }
}