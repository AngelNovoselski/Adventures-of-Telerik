using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Hunter : Hero, IHunter, IAgility
    {
        private int agility;
        private int energy;
        private Weapon weapon;

        public Hunter()
            : base()
        {
            this.Energy = 100;
            this.Agility = 20;
            this.Weapon = new Bow();
        }

        public override int Energy { get => this.energy; set => energy = value; }
        public int Agility { get => agility; set => agility = value; }
        public override Weapon Weapon { get => this.weapon; set => this.weapon = value; }

        public override int FocusShot()
        {
            if (this.Energy >= 20)
            {
                this.Energy -= 20;
                return this.Agility + this.Weapon.Dmg;
            }
            else
            {
                return 0;
            }
        }
    }
}
