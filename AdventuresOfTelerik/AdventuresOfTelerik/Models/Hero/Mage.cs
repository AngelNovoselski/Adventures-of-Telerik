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
    public class Mage : Hero, IMage
    {
        private int specialEnergy;
        private int intelligence;
        private Weapon weapon;

        public Mage() :
            base(HeroColor.darkBlue)
        {
            this.Intelligence = 18;
            this.SpecialEnergy = 200;
            this.Weapon = new Staff();
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Intelligence must be positive number!!!");
                }
                this.intelligence = value;
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
                    throw new NegativeArgumentException("Mana must be positive number!!!");
                }
                this.specialEnergy = value;
            }
        }

        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int SpecialAttack()
        {
            if (this.SpecialEnergy >= 35)
            {
                this.SpecialEnergy -= 35;
                return this.Intelligence + this.Weapon.SpecialDmg + this.Weapon.Dmg;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Attack: CastSpell, Mana: {this.SpecialEnergy}";
        }
    }
}
