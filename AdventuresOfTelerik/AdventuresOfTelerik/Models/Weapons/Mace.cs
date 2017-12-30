using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Mace : Weapon, IMace
    {
        private int weaponStrength;

        public Mace()
            : base(18)
        {
            this.WeaponStrength = 5;
            this.SpecialDmg = this.Dmg + this.WeaponStrength/2;
        }

        public int WeaponStrength
        {
            get
            {
                return this.weaponStrength;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Strenght must be positive number!");
                }
                this.weaponStrength = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", Dmg: {this.Dmg}, WeaponStrength: {this.WeaponStrength}, SpecialDmg: {this.SpecialDmg}";
        }
    }
}
