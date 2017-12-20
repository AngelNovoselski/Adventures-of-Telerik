using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Knife:Weapon
    {
        public Knife() : base()
        {
            this.Dmg = 5;
        }
        public override string ToString()
        {
            return "Knife";
        }
    }
}
