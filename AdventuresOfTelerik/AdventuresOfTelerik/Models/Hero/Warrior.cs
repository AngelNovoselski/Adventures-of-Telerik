using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Warrior : Hero, IWarrior
    {
        private const int WarriorStrngthValue = 16;
        private const int WarriorSpecialEnergyValue = 131;

        private int strength;
        private int specialEnergy;

        public Warrior(IWeapon mace, IKnife knife) :
            base(HeroColor.magenta, knife)
        {
            this.Strength = WarriorStrngthValue;
            this.SpecialEnergy = WarriorSpecialEnergyValue;
            this.Weapon = mace;
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Strength must be positive number!!!");
                }
                this.strength = value;
            }
        }

        public override int SpecialEnergy
        {
            get
            {
                return this.specialEnergy;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Fury must be positive number!!!");
                }
                this.specialEnergy = value;
            }
        }

        public override int SpecialAttack()
        {
            if (this.SpecialEnergy >= 40)
            {
                this.SpecialEnergy -= 40;
                return this.Strength + this.Weapon.SpecialDmg;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Attack: RageAnger, Fury: {this.SpecialEnergy}, Strength: {this.Strength}";
        }
    }
}
