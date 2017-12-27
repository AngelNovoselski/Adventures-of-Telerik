using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Staff : Weapon, IIntelligence, IStaff
    {
        private int intelligence;

        public Staff() :base(10)
        {
            this.Intelligence = 20;   //number is not final
        }

        public int Intelligence { get => intelligence; set => intelligence = value; }

        public override string Additionalinfo()
        {
            return $"\nIntelligence: {this.Intelligence}";
        }
    }
}
