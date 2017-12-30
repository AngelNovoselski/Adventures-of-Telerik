using AdventuresOfTelerik.Contracts.HeroInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Models.Weapons;
using AdventuresOfTelerik.Common.Enums;

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
        private Weapon weapon;
        private Weapon weaponSecond;
        private readonly HeroColor heroColor;

        public Hero(HeroColor heroColor)
        {
            this.PositionX = 1;
            this.PositionY = 1;
            this.Name = "Telerik";
            this.Hp = 444;
            this.Level = 1;
            this.Exp = 0;
            this.Weapon = weapon;
            this.WeaponSecond = new Knife();
            this.heroColor = heroColor;
        }

        public int PositionX { get => this.positionX; set => this.positionX = value; }
        public int PositionY { get => this.positionY; set => this.positionY = value; }
        public string Name { get => this.name; set => this.name = value; }
        public int Hp { get => this.hp; set => this.hp = value; }
        public int Level { get => this.level; set => this.level = value; }
        public int Exp { get => this.exp; set => this.exp = value; }

        public virtual Weapon Weapon
        {
            get
            {
                return this.weapon;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon must be created!!!");
                }
                this.weapon = value;
            }
        }

        public Weapon WeaponSecond
        {
            get
            {
                return this.weaponSecond;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon must be created!!!");
                }
                this.weaponSecond = value;
            }
        }

        public HeroColor HeroColor { get => this.heroColor; }

        public abstract int SpecialEnergy { get; set; }

        public abstract int SpecialAttack();

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

        public override string ToString()
        {
            return $"Hero Hp: {this.Hp}, Name: {this.Name}\n" +
                $"{this.Additionalinfo()}\n" +
                $"Hero Weapon:{this.Weapon.ToString()}\nHero Secret Weapon:{this.WeaponSecond.ToString()}";
        }

        public virtual string Additionalinfo()
        {
            return string.Empty;
        }
    }
}


