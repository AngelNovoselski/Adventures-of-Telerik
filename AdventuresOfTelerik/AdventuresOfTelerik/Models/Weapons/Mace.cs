using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Mace : Weapon, IWeaponStrength
    {
        private int weaponStrength;

        public Mace()
            : base(20)
        {
            this.WeaponStrength = 9;
        }

        public override int WeaponStrength
        {
            get
            {
                return this.weaponStrength;
            }
            set
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
            return $", WeaponStrength: {this.WeaponStrength}";
        }
    }
}
