using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.Enemies;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Factories
{
    public interface IGameFactory
    {
        Map CreateMap();

        Mage CreateMage();

        Warrior CreateWarrior();

        Hunter CreateHunter();

        Monster CreateMonster();

        BossMonster CreateBossMonster();

        Dragon CreateDragon();

        BossDragon CreateBossDragon();
    }
}
