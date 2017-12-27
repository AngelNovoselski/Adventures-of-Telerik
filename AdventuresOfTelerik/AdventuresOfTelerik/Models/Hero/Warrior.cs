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
    public class Warrior : Hero, IWarrior, IStrenght
    {
        private int strenght;
        private int fury;
        public Warrior() :
            base(new Mace())
        {
            Fury = 100;
            Strenght = 20; // Number not final;
        }

        public int Strenght { get => strenght; set => strenght = value; }
        public int Fury { get => fury; set => fury = value; }
    }
}
