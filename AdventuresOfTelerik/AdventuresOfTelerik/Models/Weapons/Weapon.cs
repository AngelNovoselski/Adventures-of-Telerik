using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public abstract class Weapon : IWeapon, IAmmo, IWeaponAgility, IStrength, IIntelligence
    {
        private int dmg;

        public Weapon(int dmg)
        {
            this.Dmg = dmg;
        }

        public int Dmg
        {
            get
            {
                return this.dmg;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage must be positive number!");
                }
                this.dmg = value;
            }
        }

        public virtual int Ammo { get; set; }
        public virtual int WeaponAgility { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Intelligence { get; set; }

        public override string ToString()
        {
            return $" {this.GetType().Name}, Dmg: {this.Dmg}{this.Additionalinfo()}";
        }

        public virtual string Additionalinfo()
        {
            return string.Empty;
        }
    }
}
