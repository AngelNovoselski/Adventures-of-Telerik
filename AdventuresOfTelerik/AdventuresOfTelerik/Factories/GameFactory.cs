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
    public class GameFactory : IFactory
    {
        public BossDragon CreateBossDragon()
        {
            BossDragon dragBoss = new BossDragon();
            return dragBoss;
        }
        public BossMonster CreateBossMonster()
        {
            BossMonster monstBoss = new BossMonster();
            return monstBoss;
        }
        public Bow CreateBow()
        {
            Bow bow = new Bow();
            return bow;
        }
        public Dragon CreateDragon()
        {
            Dragon drag = new Dragon();
            return drag;
        }
        public Hunter CreateHunter()
        {
            Hunter hunt = new Hunter();
            return hunt;
        }

        public Knife CreateKnife()
        {
            Knife knife = new Knife();
            return knife;
        }

        public Mace CreateMace()
        {
            Mace mace = new Mace();
            return mace;
        }

        public Mage CreateMage()
        {
            Mage mag= new Mage();

            return mag;
        }

        public Monster CreateMonster()
        {
            Monster mosnt = new Monster();

            return mosnt;
        }

        public Staff CreateStaff()
        {
            Staff sta = new Staff();

            return sta;
        }

        public Warrior CreateWarrior()
        {
            Warrior war = new Warrior();

            return war;
        }

        public Map CreateMap()
        {
            Map map = new Map();

            return map;
        }
    }
}
