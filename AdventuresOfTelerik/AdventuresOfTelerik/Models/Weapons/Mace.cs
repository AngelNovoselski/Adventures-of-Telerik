using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Mace : Weapon, IStrength
    {
        private int strength;

        public Mace()
            : base(20)
        {
            this.Strength = 20;
        }

        public override int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Strenght must be positive number!");
                }
                this.strength = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", Strength: {this.Strength}";
        }
    }
}
