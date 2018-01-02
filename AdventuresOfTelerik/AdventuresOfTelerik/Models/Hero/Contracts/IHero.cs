using AdventuresOfTelerik.Common.Enums;
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
        //int Level { get; set; }
        //int Exp { get; set; }
        HeroColor HeroColor { get; }
        Weapon Weapon { get; set; }
        Weapon WeaponSecond { get; set; }
        int SpecialEnergy { get; set; }
        int SpecialAttack();
        void Move(int input);
        string ToString();
        string Additionalinfo();
    }
}
