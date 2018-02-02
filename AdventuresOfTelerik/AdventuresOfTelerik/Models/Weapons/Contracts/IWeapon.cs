using AdventuresOfTelerik.Models.Weapons.Contracts;

namespace AdventuresOfTelerik.Contracts.WeaponInterfaces
{
    public interface IWeapon : ISpecialDamage
    {
        int Dmg { get; }
        string Additionalinfo();
    }
}
