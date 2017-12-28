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
        private int hp;
        private int dmg;
        private int energy;

        public Enemy()
        {
            this.Hp = hp;
            this.Dmg = dmg;
            this.Energy = energy;
        }

        public int Hp { get; set; }
        public int Dmg { get; set; }
        public int Energy { get; set; }
    }
}
