using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Common.Enums;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Hunter : Hero, IHunter, IAgility
    {
        private int agility;
        private int energy;
        private Weapon weapon;

        public Hunter()
            : base(HeroColor.red)
        {
            this.Agility = 15;
            this.Energy = 99;
            this.Weapon = new Bow();
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Agility must be positive number!!!");
                }
                this.agility = value;
            }
        }

        public override int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Energy must be positive number!!!");
                }
                this.energy = value;
            }
        }

        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int FocusShot()
        {
            if (this.Energy >= 44)
            {
                this.Energy -= 44;
                return this.Agility + this.Weapon.Dmg + this.Weapon.WeaponAgility;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Ability: FocusShot, Energy: {this.Energy}, Agility: {this.Agility}";
        }
    }
}
