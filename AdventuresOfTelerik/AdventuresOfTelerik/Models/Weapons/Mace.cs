using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Mace : Weapon, IWeapon, IMace
    {
        private int weaponStrength;

        private const int WEAPON_STRENGTH = 5;
        private const int BASE_DMG = 18;
        private const int DMG_DIVIDER = 2;

        public Mace()
            : base(BASE_DMG)
        {
            this.WeaponStrength = WEAPON_STRENGTH;
            this.SpecialDmg = this.Dmg + this.WeaponStrength / DMG_DIVIDER;
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
