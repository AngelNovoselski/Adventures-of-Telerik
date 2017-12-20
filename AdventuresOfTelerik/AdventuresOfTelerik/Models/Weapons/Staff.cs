using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Staff : Weapon
    {
        public Staff() :base()
        {
            this.Dmg = 10;
        }
        public override string ToString()
        {
            return "Staff";
        }
    }
}
