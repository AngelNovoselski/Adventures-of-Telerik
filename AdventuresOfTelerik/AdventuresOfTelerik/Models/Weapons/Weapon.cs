using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        

        public Weapon()
        {
            this.Dmg = Dmg;
        }
        protected int dmg;
        public int Dmg { get => dmg; set => dmg = value; }

        public override string ToString()
        {
            return "Shouldnt return this-.-";
        }
    }
}
