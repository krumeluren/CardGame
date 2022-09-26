namespace RepositoryContracts;

public interface IRepoManager
{
    public void Save();
    public ICardRepo Cards { get; }
    public ICardHistoryRepo PlayerCardHistory { get; }
    public IPlayerRepo Players { get; }
}

