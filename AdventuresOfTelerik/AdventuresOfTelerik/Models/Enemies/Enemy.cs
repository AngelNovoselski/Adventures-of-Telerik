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

        public int Hp
        {
            get
            {
                return this.hp;
            }
            set
            {
                //if (value < 0)
                //{
                //    throw new NegativeArgumentException("Hp must be positive number!!!");
                //}
                this.hp = value;
            }
        }

        public int Dmg
        {
            get
            {
                return this.dmg;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Dmg must be positive number!!!");
                }
                this.dmg = value;
            }
        }

        public int Energy
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

        public virtual int Roar() { throw new NotImplementedException("This enemy doesn't have this ability!!!"); }
    }
}
