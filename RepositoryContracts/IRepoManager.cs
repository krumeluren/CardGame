namespace RepositoryContracts;

/// <summary>
/// This interface is used to implement and access all repositories.
/// </summary>
public interface IRepoManager
{
    public void Save();
    public ICardRepo Cards { get; }
    public ICardHistoryRepo PlayerCardHistory { get; }
    public IPlayerRepo Players { get; }
}

