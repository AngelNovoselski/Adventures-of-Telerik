using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Enemies
{
    public abstract class Enemy : IEnemy
    {
  

        public Enemy()
        {
            this.Hp = 100;
            this.Dmg = 1;
            this.Energy = 10;
        }
        public int Hp { get; set; }
        public int Dmg { get; set; }
        public int Energy { get; set; }
    }
}
