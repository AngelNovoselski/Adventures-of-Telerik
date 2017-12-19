using AdventuresOfTelerik.Contracts.HeroInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;

namespace AdventuresOfTelerik.Models.Hero
{
    public abstract class Hero : IHero
    {
        private int positionX;
        private int positionY;
        private string name;
        private int hp;
        private int level;
        private int exp;
        private IWeapon weapon;
        public Hero()
        {

        }
        public int PositionX { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PositionY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Hp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Level { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Exp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWeapon Weapon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
