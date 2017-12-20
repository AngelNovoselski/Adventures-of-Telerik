using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace() : base()
        {
            this.Dmg = 20;
        }
        public override string ToString()
        {
            return "Mace";
        }
    }
}
