using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Mace : Weapon, IStrenght, IMace
    {
        private int strenght;

        public Mace()
            : base(20)
        {
            this.Strenght = 20;
        }

        public int Strenght
        {
            get
            {
                return this.strenght;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Strenght must be positive number!");
                }
                this.strenght = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", Strenght: {this.Strenght}";
        }
    }
}
