using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;

namespace AdventuresOfTelerik.Models.Weapons
{
    public class Bow:Weapon, IAgility, IBow

    {
        private int agility;
        private int ammo;
        public Bow() : base(15)
        {
            this.Agility = 20; // Number not final
            this.Ammo = 10; //Number not final
        }

        public int Agility { get => agility; set => agility = value; }
        public int Ammo { get => ammo; set => ammo = value; }

        public override string ToString()
        {
            return $"\nAgility: {this.Agility}\nAmmo: {this.Ammo}";
        }
    }
}
