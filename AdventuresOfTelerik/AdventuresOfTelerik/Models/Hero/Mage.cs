using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;

namespace AdventuresOfTelerik.Models.Hero
{
    public class Mage : Hero, IMage
    {
        private const int MageIntelligence = 20;
        private const int MageSpecialEnergy = 120;

        private int specialEnergy;
        private int intelligence;

        public Mage(IWeapon staff, IKnife knife)
            : base(HeroColor.darkBlue, knife)
        {
            this.Intelligence = MageIntelligence;
            this.SpecialEnergy = MageSpecialEnergy;
            this.Weapon = staff;
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeArgumentException("Intelligence must be positive number!!!");
                }
                this.intelligence = value;
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
                    throw new NegativeArgumentException("Mana must be positive number!!!");
                }
                this.specialEnergy = value;
            }
        }

        public override int SpecialAttack()
        {
            if (this.SpecialEnergy >= 35)
            {
                this.SpecialEnergy -= 35;
                return this.Intelligence + this.Weapon.SpecialDmg;
            }
            else
            {
                return 0;
            }
        }

        public override string Additionalinfo()
        {
            return $"Special Attack: CastSpell, Mana: {this.SpecialEnergy}, Intelligence: {this.Intelligence}";
        }
    }
}
