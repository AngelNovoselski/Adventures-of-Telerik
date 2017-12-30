using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Knife : Weapon, IKnife
    {
        private int weaponAgility;

        public Knife()
            : base(11)
        {
            this.WeaponAgility = 4;
            this.Dmg += this.WeaponAgility/2;
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
