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
        private Weapon weapon;

        public Mage() :
            base()
        {
            this.Mana = 90;
            this.Intelligence = 18;
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
                    throw new ArgumentException("Intelligence must be positive number!!!");
                }
                this.intelligence = value;
            }
        }

        public override int Mana
        {
            get
            {
                return this.mana;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Mana must be positive number!!!");
                }
                this.mana = value;
            }
        }

        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int CastSpell()
        {
            if (this.Mana >= 35)
            {
                this.Mana -= 35;
                return this.Intelligence + this.Weapon.Dmg + this.Weapon.WeaponIntelligence;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Ability: CastSpell, Mana: {this.Mana}, Intelligence: {this.Intelligence}";
        }
    }
}
