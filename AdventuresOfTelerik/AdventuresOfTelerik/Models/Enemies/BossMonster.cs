using AdventuresOfTelerik.Contracts.EnemyInterfaces;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class BossMonster : Monster, IBoss
    {
        private const int HpValue = 150;
        private const int DmgValue = 20;
        private const int EnergyValue = 20;

        public BossMonster()
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
                return this.Dmg * 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
