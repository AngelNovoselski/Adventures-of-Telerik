using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Knife : Weapon, IAgility, IKnife
    {
        private int agility;

        public Knife() 
            : base(5)
        {
            this.Agility = 25;
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

        public override string Additionalinfo()
        {
            return $", Agility: {this.Agility}";
        }
    }
}
