namespace AdventuresOfTelerik.Contracts
{
    public interface IMap
    {
        int Row { get; }
        int Col { get; }
        char[,] FirstMap { get; }
    }
}
