using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Knife : Weapon, IWeapon, IKnife
    {
        private int weaponAgility;

        private const int WEAPON_AGILITY = 4;
        private const int BASE_DMG = 11;
        private const int DMG_DIVIDER = 2;

        public Knife()
            : base(BASE_DMG)
        {
            this.WeaponAgility = WEAPON_AGILITY;
            this.Dmg += this.WeaponAgility / DMG_DIVIDER;
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
                    throw new ArgumentException("Agility must be positive number!");
                }
                this.weaponAgility = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", Dmg: {this.Dmg}, WeaponAgility: {this.WeaponAgility}";
        }
    }
}
