using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

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
        HeroColor HeroColor { get; }
        IWeapon Weapon { get; set; }
        IWeapon WeaponSecond { get; set; }
        int SpecialEnergy { get; set; }
        int SpecialAttack();
        void Move(int input);
        string Additionalinfo();
        void OnFightMonster();
        event EventHandler FightMonster;
    }
}
