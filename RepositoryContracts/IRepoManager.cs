namespace RepositoryContracts;

public interface IRepoManager
{
    public void Save();
    public ICardRepo Cards { get; }
}

