using AdventuresOfTelerik.Contracts.EnemyInterfaces;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class Monster : Enemy, IMonster
    {
        private const int HpValue = 100;
        private const int DmgValue = 10;
        private const int EnergyValue = 10;

        public Monster()
            : base()
        {
            this.Hp = HpValue;
            this.Dmg = DmgValue;
            this.Energy = EnergyValue;
        }

        public override int Roar()
        {
            if (this.Energy >= 5)
            {
                this.Energy -= 5;
                return this.Dmg * 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
