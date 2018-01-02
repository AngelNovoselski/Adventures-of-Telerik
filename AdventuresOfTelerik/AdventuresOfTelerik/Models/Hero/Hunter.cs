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
    public class Hunter : Hero, IHunter
    {
        private int agility;
        private int specialEnergy;
        private Weapon weapon;

        public Hunter()
            : base(HeroColor.red)
        {
            this.Agility = 15;
            this.SpecialEnergy = 200;
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
                    throw new NegativeArgumentException("Energy must be positive number!!!");
                }
                this.specialEnergy = value;
            }
        }

        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int SpecialAttack()
        {
            if (this.SpecialEnergy >= 44)
            {
                this.SpecialEnergy -= 44;
                return this.Agility + this.Weapon.SpecialDmg + this.Weapon.Dmg;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Attack: FocusShot, Energy: {this.SpecialEnergy}";
        }
    }
}
