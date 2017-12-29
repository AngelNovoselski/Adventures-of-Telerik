using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Bow : Weapon, IAmmo, IWeaponAgility
    {
        private int weaponAgility;
        private int ammo;

        public Bow()
            : base(15)
        {
            this.WeaponAgility = 11;
            this.Ammo = 5;
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
                    throw new ArgumentException("WeaponAgility must be positive number!");
                }
                this.weaponAgility = value;
            }
        }

        public override int Ammo
        {
            get
            {
                return this.ammo;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ammo must be positive number!");
                }
                this.ammo = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", WeaponAgility: {this.WeaponAgility}, Ammo: {this.Ammo}";
        }
    }
}
