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
    public class Mage : Hero, IMage, IIntelligence
    {
        private int mana;
        private int intelligence;
        public Mage() : 
            base(new Staff())
        {
            Mana = 100;
            Intelligence = 20; //Number not final
        }

        public int Mana { get => mana; set => mana = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
    }
}
