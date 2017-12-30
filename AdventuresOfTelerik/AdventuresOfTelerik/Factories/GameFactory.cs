using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Models.Enemies;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models.Weapons;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;

namespace AdventuresOfTelerik.Factories
{
    public class GameFactory : IGameFactory
    {
        public Map CreateMap()
        {
            Map map = new Map();
            return map;
        }

        public Mage CreateMage()
        {
            Mage mage = new Mage();
            return mage;
        }

        public Warrior CreateWarrior()
        {
            Warrior warrior = new Warrior();
            return warrior;
        }

        public Hunter CreateHunter()
        {
            Hunter hunter = new Hunter();
            return hunter;
        }

        public Monster CreateMonster()
        {
            Monster monster = new Monster();
            return monster;
        }

        public BossMonster CreateBossMonster()
        {
            BossMonster bossMonster = new BossMonster();
            return bossMonster;
        }

        public Dragon CreateDragon()
        {
            Dragon dragon = new Dragon();
            return dragon;
        }

        public BossDragon CreateBossDragon()
        {
            BossDragon bossDragon = new BossDragon();
            return bossDragon;
        }
    }
}
