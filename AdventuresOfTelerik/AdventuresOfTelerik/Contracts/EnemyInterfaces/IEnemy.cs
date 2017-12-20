using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Contracts.EnemyInterfaces
{
    public interface IEnemy
    {
        int Hp { get; set; }
        int Dmg { get; set; }
        int Energy { get; set; }
    }
}
