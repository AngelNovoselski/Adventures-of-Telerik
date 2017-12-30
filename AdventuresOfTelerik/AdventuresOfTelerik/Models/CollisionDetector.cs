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
        private const string ExitMessage = "You see the exit of the labyrinth!!!";
        private const string BossMonsterMessage = "The ground arround you trembles as the visious Xlliyu the spawn of Cthulhu appears before you!\n     It is time to prove you are worthy to protect this realm!";
        private const string MonsterMessage = "You see a dark silhouette! Weird that you cant see what it is even tought its midday.";
        private const string PathMessage = "There is a path! It looks safe but you have a feeling this may not be the case.";
        private const string RockMessage = "There is a giant rock! If you dont want to get hurt you better not try anything funny like climbing it.";

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
                msg = PathMessage;
                return msg;
            }
            else if (a == '@')
            {
                msg = RockMessage;
                return msg;
            }
            else if (a == '1')
            {
                msg = MonsterMessage;
                return msg;
            }
            else if (a == '2')
            {
                msg = BossMonsterMessage;
                return msg;
            }
            else if (a == 'x')
            {
                msg = ExitMessage;
                return msg;
            }
            return string.Empty;
        }
    }
}
