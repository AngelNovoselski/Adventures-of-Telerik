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
        private Weapon weapon;

        public Warrior() :
            base()
        {
            this.Fury = 100;
            this.Strength = 20;
            this.Weapon = new Mace();
        }

        public int Strength { get => strength; set => strength = value; }
        public override int Fury { get => fury; set => fury = value; }
        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int RageAnger()
        {
            if (this.Fury >= 40)
            {
                this.Fury -= 40;
                return this.Strength + this.Weapon.Dmg;
            }
            else
            {
                return 0;
            }
        }
    }
}
