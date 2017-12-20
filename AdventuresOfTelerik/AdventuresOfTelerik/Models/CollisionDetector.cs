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
                msg = "n empty path..";
                return msg;
            }
            else if (a == '@')
            {
                msg = " tree there!";
                return msg;
            }
            else if (a == '1')
            {
                msg = " dangerous monster ahead";
                return msg;
            }
            return string.Empty;
        }
    }
}
