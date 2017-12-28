using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class BossMonster: Enemy
    {
        public BossMonster() 
            : base()
        {
            this.Hp = 150;
            this.Dmg = 20;
            this.Energy = 20;
        }
    }
}
