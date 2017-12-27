using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.Weapons;
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
        int Energy { get; set; }
        Weapon Weapon{ get; set; }
        void Move(int input);
        void Print();
    }
}
