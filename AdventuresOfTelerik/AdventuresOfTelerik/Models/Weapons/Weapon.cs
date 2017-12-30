using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int dmg;
        private int specialDmg;

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
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage must be positive number!");
                }
                this.dmg = value;
            }
        }

        public virtual int SpecialDmg
        {
            get
            {
                return this.specialDmg;
            }
            protected set
            {
                this.specialDmg = value;
            }
        }

        public virtual int Ammo { get; set; }

        public override string ToString()
        {
            return $" {this.GetType().Name}{this.Additionalinfo()}";
        }

        public virtual string Additionalinfo()
        {
            return string.Empty;
        }
    }
}
