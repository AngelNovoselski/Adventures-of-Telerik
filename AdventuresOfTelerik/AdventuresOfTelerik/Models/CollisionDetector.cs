using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public static class CollisionDetector
    {
        public static string CheckCollisions(int positionX, int positionY, Map map)
        {
            string result = "";
            result = map.FirstMap[positionX, positionY].ToString();
            return result;
        }
    }
}
