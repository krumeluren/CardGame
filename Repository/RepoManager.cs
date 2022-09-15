using RepositoryContracts;

namespace Repository;

public class RepoManager : IRepoManager
{
    private readonly RepoContext _repoContext;
    private readonly Lazy<ICardRepo> _cardRepo;

    public RepoManager(RepoContext repoContext)
    {
        _repoContext = repoContext;
        _cardRepo = new Lazy<ICardRepo>(() => new CardRepo(_repoContext));
    }
    
    public ICardRepo Cards => _cardRepo.Value;

    public void Save() => _repoContext.SaveChanges();
    
}
