using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Bow : Weapon, IAgility, IBow
    {
        private int agility;
        private int ammo;

        public Bow() 
            : base(15)
        {
            this.Agility = 20;
            this.Ammo = 10;
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Agility must be positive number!");
                }
                this.agility = value;
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
            return $", Agility: {this.Agility}, Ammo: {this.Ammo}";
        }
    }
}
