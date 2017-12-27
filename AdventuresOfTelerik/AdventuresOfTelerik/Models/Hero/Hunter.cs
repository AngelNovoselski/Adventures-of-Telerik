using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Hunter : Hero, IHunter, IAgility
    {
        private int agility;
        private int energy;
        public Hunter()
            : base(new Bow())
        {
            Energy = 100;
            Agility = 20; //Number not final
        }

        public int Energy { get => energy; set => energy = value; }
        public int Agility { get => agility; set => agility = value; }

        public int FocusShot()
        {
            throw new NotImplementedException();
        }
    }
}
