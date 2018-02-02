using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Common.Enums;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Hunter : Hero, IHunter
    {
        private const int HunterAgilityValue = 15;
        private const int HunterSpecialEnergyValue = 150;

        private int agility;
        private int specialEnergy;

        public Hunter(IWeapon bow, IKnife knife)
            : base(HeroColor.red, knife)
        {
            this.Agility = HunterAgilityValue;
            this.SpecialEnergy = HunterSpecialEnergyValue;
            this.Weapon = bow;
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Agility must be positive number!!!");
                }
                this.agility = value;
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
                    throw new NegativeArgumentException("Energy must be positive number!!!");
                }
                this.specialEnergy = value;
            }
        }

        public override int SpecialAttack()
        {
            if (this.SpecialEnergy >= 44)
            {
                this.SpecialEnergy -= 44;
                return this.Agility + this.Weapon.SpecialDmg;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Attack: FocusShot, Energy: {this.SpecialEnergy}, Agility: {this.Agility}";
        }
    }
}
