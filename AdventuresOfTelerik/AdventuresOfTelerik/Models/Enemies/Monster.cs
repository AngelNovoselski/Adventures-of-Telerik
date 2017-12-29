using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Models.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class Monster : Enemy, IMonster
    {
        public Monster() 
            : base()
        {
            this.Hp = 100;
            this.Dmg = 10;
            this.Energy = 10;
        }

        public override int Roar()
        {
            if (this.Energy >= 5)
            {
                this.Energy -= 5;
                return this.Dmg * 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
