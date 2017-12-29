using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Knife : Weapon, IWeaponAgility
    {
        private int weaponAgility;

        public Knife()
            : base(5)
        {
            this.WeaponAgility = 7;
        }

        public override int WeaponAgility
        {
            get
            {
                return this.weaponAgility;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Agility must be positive number!");
                }
                this.weaponAgility = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", WeaponAgility: {this.WeaponAgility}";
        }
    }
}
