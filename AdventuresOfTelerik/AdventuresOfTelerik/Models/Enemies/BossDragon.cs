using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class BossDragon: Dragon, IBoss
    {
        public BossDragon()
            : base()
        {
            this.Hp = 166;
            this.Dmg = 21;
            this.Energy = 20;
        }

        public override int Roar()
        {
            if (this.Energy >= 5)
            {
                this.Energy -= 5;
                return this.Dmg * 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
