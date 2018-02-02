using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Staff : Weapon, IWeapon, IStaff
    {
        private int weaponIntelligence;

        private const int WEAPON_INTELLIGENCE = 12;
        private const int BASE_DMG = 17;
        private const int DMG_DIVIDER = 2;

        public Staff()
            : base(BASE_DMG)
        {
            this.WeaponIntelligence = WEAPON_INTELLIGENCE;
            this.SpecialDmg = this.Dmg + this.WeaponIntelligence / DMG_DIVIDER;
        }

        public int WeaponIntelligence
        {
            get
            {
                return this.weaponIntelligence;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Intelligence must be positive number!");
                }
                this.weaponIntelligence = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", Dmg: {this.Dmg}, WeaponIntelligence: {this.WeaponIntelligence}, SpecialDmg: {this.SpecialDmg}";
        }
    }
}
