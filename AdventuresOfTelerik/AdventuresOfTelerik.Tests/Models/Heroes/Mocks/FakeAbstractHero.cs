using System;
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

        public override int SpecialEnergy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int SpecialAttack()
        {
            throw new NotImplementedException();
        }
    }
}
