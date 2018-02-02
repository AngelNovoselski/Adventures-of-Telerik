using System;
using System.Collections.Generic;
using AdventuresOfTelerik.Models.Enemies;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models.Weapons;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;

namespace AdventuresOfTelerik.Factories
{
    public class GameFactory : IGameFactory
    {
        public IMap CreateMap()
        {
            return new Map();
        }

        public IMage CreateMage(IStaff staff, IKnife knife)
        {
            return new Mage(staff, knife);
        }

        public IWarrior CreateWarrior(IMace mace, IKnife knife)
        {
            return new Warrior(mace, knife);
        }

        public IHunter CreateHunter(IBow bow, IKnife knife)
        {
            return new Hunter(bow, knife);
        }

        private IDictionary<string, Func<IHero>> heroTypeMapper;

        public void HeroFactory()
        {
            heroTypeMapper = new Dictionary<string, Func<IHero>>();
            heroTypeMapper.Add("Mage", () => { return CreateMage(new Staff(), new Knife()); });
            heroTypeMapper.Add("Warrior", () => { return CreateWarrior(new Mace(), new Knife()); });
            heroTypeMapper.Add("Hunter", () => { return CreateHunter(new Bow(), new Knife()); });
        }

        public IHero GetHeroBasedOnType(string heroType)
        {
            return heroTypeMapper[heroType]();
        }

        public IMonster CreateMonster()
        {
            return new Monster();
        }

        public IMonster CreateBossMonster()
        {
            return new BossMonster();
        }

        public IDragon CreateDragon()
        {
            return new Dragon();
        }

        public IDragon CreateBossDragon()
        {
            return new BossDragon();
        }

        public IHeroCoordinates CreateHeroCoordinates(IHero hero)
        {
            return new HeroCoordinates(hero);
        }
    }
}
