using AdventuresOfTelerik.Contracts.EnemyInterfaces;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class BossDragon : Dragon, IBoss
    {
        private const int HpValue = 166;
        private const int DmgValue = 21;
        private const int EnergyValue = 20;

        public BossDragon()
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
