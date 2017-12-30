using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Contracts.EnemyInterfaces
{
    public interface IEnemy
    {
        int Hp { get; }
        int Dmg { get; }
        int Energy { get; }
        int Roar();
    }
}
