using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Models
{
    public class CollisionDetector : ICollisionDetector
    {
        public char CheckCollisions(int positionX, int positionY, IMap map)
        {
            char result = ' ';
            result = map.FirstMap[positionX, positionY];
            return result;
        }

        public string GuideMessage(char a)
        {
            if (a == '-')
            {
                return GlobalMessages.PathMessage;
            }
            else if (a == '@')
            {
                return GlobalMessages.RockMessage;
            }
            else if (a == '1')
            {
                return GlobalMessages.MonsterMessage;
            }
            else if (a == '2')
            {
                return GlobalMessages.BossMonsterMessage;
            }
            else if (a == 'x')
            {
                return GlobalMessages.ExitMessage;
            }
            return string.Empty;
        }
    }
}
