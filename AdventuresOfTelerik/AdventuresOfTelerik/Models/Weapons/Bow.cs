using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Bow:Weapon

    {
        public Bow() : base()
        {
            this.Dmg = 15;
        }
        public override string ToString()
        {
            return "Bow";
        }
    }
}
