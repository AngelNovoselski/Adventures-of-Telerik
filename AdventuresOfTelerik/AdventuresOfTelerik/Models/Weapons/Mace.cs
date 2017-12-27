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
        public Mace() : base(20)
        {
            this.Strenght = 20; // number not final
        }

        public int Strenght { get => strenght; set => strenght = value; }

        public override string Additionalinfo()
        {
            return $"\nStrenght: {this.Strenght}";
        }
    }
}
