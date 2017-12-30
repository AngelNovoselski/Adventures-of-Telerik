using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Bow : Weapon, IBow
    {
        private int weaponAgility;
        private int ammo;

        public Bow()
            : base(19)
        {
            this.WeaponAgility = 6;
            this.SpecialDmg = this.Dmg + this.WeaponAgility/2;
            this.Ammo = 5;
        }

        public int WeaponAgility
        {
            get
            {
                return this.weaponAgility;
            }
            private set
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
            return $", Dmg: {this.Dmg}, WeaponAgility: {this.WeaponAgility}, Ammo: {this.Ammo}, SpecialDmg: {this.SpecialDmg}";
        }
    }
}
