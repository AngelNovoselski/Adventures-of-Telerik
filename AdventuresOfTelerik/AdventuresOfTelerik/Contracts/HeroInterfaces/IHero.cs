using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Contracts.HeroInterfaces
{
    public interface IHero
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        string Name { get; set; }
        int Hp { get; set; }
        int Level { get; set; }
        int Exp { get; set; }
        IWeapon Weapon{ get; set; }
        void Move();
        void Print();
    }
}
