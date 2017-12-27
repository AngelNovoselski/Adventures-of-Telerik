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
        private int intelligence;

        public Staff() 
            : base(10)
        {
            this.Intelligence = 20;
        }

        public override int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Intelligence must be positive number!");
                }
                this.intelligence = value;
            }
        }

        public override string Additionalinfo()
        {
            return $", Intelligence: {this.Intelligence}";
        }
    }
}
