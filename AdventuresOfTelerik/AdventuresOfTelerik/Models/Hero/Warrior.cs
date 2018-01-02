using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Common.Enums;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Warrior : Hero, IWarrior
    {
        private int strength;
        private int specialEnergy;
        private Weapon weapon;

        public Warrior() :
            base(HeroColor.magenta)
        {
            this.Strength = 16;
            this.SpecialEnergy = 131;
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
                    throw new NegativeArgumentException("Strength must be positive number!!!");
                }
                this.strength = value;
            }
        }

        public override int SpecialEnergy
        {
            get
            {
                return this.specialEnergy;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Fury must be positive number!!!");
                }
                this.specialEnergy = value;
            }
        }

        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int SpecialAttack()
        {
            if (this.SpecialEnergy >= 40)
            {
                this.SpecialEnergy -= 40;
                return this.Strength + this.Weapon.SpecialDmg + this.Weapon.Dmg;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Attack: RageAnger, Fury: {this.SpecialEnergy}, Strength: {this.Strength}";
        }
    }
}
