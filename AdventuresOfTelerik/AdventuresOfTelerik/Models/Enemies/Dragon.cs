using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class Dragon: Enemy, IDragon
    {
        public Dragon() 
            : base()
        {
            this.Hp = 111;
            this.Dmg = 11;
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
