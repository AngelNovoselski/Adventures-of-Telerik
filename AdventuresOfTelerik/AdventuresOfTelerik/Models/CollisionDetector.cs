using AdventuresOfTelerik.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public static class CollisionDetector
    {
        public static char CheckCollisions(int positionX, int positionY, Map map)
        {
            char result = ' ';
            result = map.FirstMap[positionX, positionY];
            return result;
        }
        public static string GuideMessage(char a)
        {
            var msg = "";

            if (a == '-')
            {
                msg = GameEngine.PathMessage;
                return msg;
            }
            else if (a == '@')
            {
                msg = GameEngine.RockMessage;
                return msg;
            }
            else if (a == '1')
            {
                msg = GameEngine.MonsterMessage;
                return msg;
            }
            else if (a == '2')
            {
                msg = GameEngine.BossMonsterMessage;
                return msg;
            }
            else if (a == 'x')
            {
                msg = GameEngine.ExitMessage;
                return msg;
            }
            return string.Empty;
        }
    }
}
