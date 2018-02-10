using System;
using System.Linq.Expressions;
using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;

namespace AdventuresOfTelerik.Tests.Models.Heroes.Mocks
{
    public class FakeAbstractHero : AdventuresOfTelerik.Models.Hero.Hero
    {
        public FakeAbstractHero(HeroColor heroColor, IKnife knife) 
            : base(heroColor, knife)
        {
        }

        public override int SpecialEnergy { get; set; }

        public override int SpecialAttack()
        {
            return default(int);
        }
    }
}
