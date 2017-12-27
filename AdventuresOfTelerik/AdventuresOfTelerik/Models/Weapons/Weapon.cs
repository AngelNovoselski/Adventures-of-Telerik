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
        public Weapon(int dmg)
        {
            this.Dmg = dmg;
        }
        private int dmg;
        public int Dmg { get => dmg; set => dmg = value; }

        public override string ToString()
        {
            return $"Weapon: {this.GetType().Name}\nDmg: {this.Dmg}{this.Additionalinfo()}";
        }
        public virtual string Additionalinfo()
        {
            return string.Empty;
        }
    }
}
