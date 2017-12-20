using AdventuresOfTelerik.Contracts.WeaponInterfaces;
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
    public interface IFactory
    {
        BossDragon CreateBossDragon();

        BossMonster CreateBossMonster();

        Monster CreateMonster();

        Dragon CreateDragon();

        Warrior CreateWarrior();

        Mage CreateMage();

        Hunter CreateHunter();

        Knife CreateKnife();

        Mace CreateMace();

        Staff CreateStaff();

        Bow CreateBow();
    }
}
