using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Contracts.HeroInterfaces
{
    public interface IMage
    {
        int Mana { get; set; }
        int CastSpell();
    }
}
