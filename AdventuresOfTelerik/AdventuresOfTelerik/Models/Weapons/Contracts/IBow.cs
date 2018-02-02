namespace AdventuresOfTelerik.Contracts.WeaponInterfaces
{
    public interface IBow : IWeapon
    {
        int WeaponAgility { get; }
        int Ammo { get; }
    }
}
