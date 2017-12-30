using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Staff : Weapon, IStaff
    {
        private int weaponIntelligence;

        public Staff()
            : base(17)
        {
            this.WeaponIntelligence = 12;
            this.SpecialDmg = this.Dmg + this.WeaponIntelligence/2;
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
