using AdventuresOfTelerik.Contracts.EnemyInterfaces;

namespace AdventuresOfTelerik.Models.Enemies
{
    public class Dragon : Enemy, IDragon
    {
        private const int HpValue = 111;
        private const int DmgValue = 11;
        private const int EnergyValue = 10;

        public Dragon()
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
