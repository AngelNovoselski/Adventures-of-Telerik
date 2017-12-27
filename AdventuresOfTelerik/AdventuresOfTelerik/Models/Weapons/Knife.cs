using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Knife:Weapon, IAgility, IKnife
    {
        private int agility;
        public Knife() : base(5)
        {
            this.Agility = 20; //number not final
        }

        public int Agility { get => agility; set => agility = value;}


        public override string Additionalinfo()
        {
            return $"\nAgility: {this.Agility}";
        }
    }
}
