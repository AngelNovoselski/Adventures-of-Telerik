using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.EnemyInterfaces;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models;

namespace AdventuresOfTelerik.Factories
{
    public interface IGameFactory
    {
        void HeroFactory();

        IHeroCoordinates CreateHeroCoordinates(IHero hero);

        IHero GetHeroBasedOnType(string heroType);

        IMap CreateMap();

        IMage CreateMage(IStaff staff, IKnife knife);

        IWarrior CreateWarrior(IMace mace, IKnife knife);

        IHunter CreateHunter(IBow bow, IKnife knife);

        IMonster CreateMonster();

        IMonster CreateBossMonster();

        IDragon CreateDragon();

        IDragon CreateBossDragon();
    }
}
