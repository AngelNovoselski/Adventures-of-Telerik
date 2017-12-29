using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Staff : Weapon, IWeaponIntelligence
    {
        private int weaponIntelligence;

        public Staff() 
            : base(10)
        {
            this.WeaponIntelligence = 12;
        }

        public override int WeaponIntelligence
        {
            get
            {
                return this.weaponIntelligence;
            }
            set
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
            return $", WeaponIntelligence: {this.WeaponIntelligence}";
        }
    }
}
