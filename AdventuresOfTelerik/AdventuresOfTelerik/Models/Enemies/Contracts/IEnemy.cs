namespace AdventuresOfTelerik.Contracts.EnemyInterfaces
{
    public interface IEnemy
    {
        int Hp { get; set; }
        int Dmg { get; }
        int Energy { get; }
        int Roar();
    }
}
