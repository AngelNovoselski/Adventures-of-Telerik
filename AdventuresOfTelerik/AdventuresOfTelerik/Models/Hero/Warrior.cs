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
            this.Fury = 88;
            this.Strength = 16;
            this.Weapon = new Mace();
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Strength must be positive number!!!");
                }
                this.strength = value;
            }
        }

        public override int Fury
        {
            get
            {
                return this.fury;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fury must be positive number!!!");
                }
                this.fury = value;
            }
        }

        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int RageAnger()
        {
            if (this.Fury >= 40)
            {
                this.Fury -= 40;
                return this.Strength + this.Weapon.Dmg + this.Weapon.WeaponStrength;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Ability: RageAnger, Fury: {this.Fury}, Strength: {this.Strength}";
        }
    }
}
