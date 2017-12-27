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
    public class Warrior : Hero, IWarrior, IStrength
    {
        private int strength;
        private int fury;
        private Weapon weapon = new Mace();

        public Warrior() :
            base()
        {
            Fury = 100;
            Strength = 20;
            this.Weapon = weapon;
        }

        public int Strength { get => strength; set => strength = value; }
        public int Fury { get => fury; set => fury = value; }
        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }
    }
}
