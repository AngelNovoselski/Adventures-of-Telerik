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
            throw new NotImplementedException();
        }

        public BossMonster CreateBossMonster()
        {
            throw new NotImplementedException();
        }

        public Bow CreateBow()
        {
            throw new NotImplementedException();
        }

        public Dragon CreateDragon()
        {
            throw new NotImplementedException();
        }

        public Hunter CreateHunter()
        {
            throw new NotImplementedException();
        }

        public Knife CreateKnife()
        {
            throw new NotImplementedException();
        }

        public Mace CreateMace()
        {
            throw new NotImplementedException();
        }

        public Mage CreateMage()
        {
            Mage mag= new Mage();

            return mag;
        }

        public Monster CreateMonster()
        {
            throw new NotImplementedException();
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
