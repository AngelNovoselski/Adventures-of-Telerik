using AdventuresOfTelerik.Contracts.HeroInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik;
using AdventuresOfTelerik.Contracts;

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
        private int energy;
        
        //private Map mappo;

        public Hero()
        {
            this.PositionX = 1;
            this.PositionY = 1;
            this.Name = "Telerik";
            this.Hp = 100;
            this.Level = 1;
            this.Exp = 0;
            this.Energy = 100;
            //this.Weapon =  IWeapon();
        }

        public int PositionX { get => positionX; set => positionX = value; }
        public int PositionY { get => positionY; set => positionY = value; }
        public string Name { get => name; set => name = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Level { get => level; set => level = value; }
        public int Exp { get => exp; set => exp = value; }
        public IWeapon Weapon { get => weapon; set => weapon = value; }
        public int Energy { get => energy; set => energy = value; }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Move(int input)
        {
            if (input == 1)
            {

                this.PositionY -= 1;

            }
            else if (input == 2)
            {
                this.PositionY += 1;
            }
            else if (input == 3)
            {
                this.PositionX -= 1;
            }
            else if (input == 4)
            {
                this.PositionX += 1;
            }
        }
    }
}


