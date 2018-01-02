﻿using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class BossMonster : Monster, IBoss
    {
        public BossMonster()
            : base()
        {
            this.Hp = 150;
            this.Dmg = 20;
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

        public override void SecondWind()
        {
            this.Hp += 50;
        }

        public override int SpecialAttack()
        {
            return this.Dmg * 3;
        }
    }
}
