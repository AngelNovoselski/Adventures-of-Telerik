using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Bow : Weapon, IWeapon, IBow
    {
        private int weaponAgility;
        private int ammo;

        private const int WEAPON_AGILITY = 6;
        private const int BASE_DMG = 19;
        private const int DMG_DIVIDER = 2;
        private const int AMMO = 5;

        public Bow()
            : base(BASE_DMG)
        {
            this.WeaponAgility = WEAPON_AGILITY;
            this.SpecialDmg = this.Dmg + this.WeaponAgility / DMG_DIVIDER;
            this.Ammo = AMMO;
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

        public int Ammo
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
