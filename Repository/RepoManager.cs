using Repository.EntityRepos;
using RepositoryContracts;

namespace Repository;

public class RepoManager : IRepoManager
{
    private readonly RepoContext _repoContext;
    private readonly Lazy<ICardRepo> _cardRepo;
    private readonly Lazy<ICardHistoryRepo> _playerCardHistoryRepo;
    private readonly Lazy<IPlayerRepo> _playerRepo;

    public RepoManager(RepoContext repoContext)
    {
        _repoContext = repoContext;
        _cardRepo = new Lazy<ICardRepo>(() => new CardRepo(_repoContext));
        _playerCardHistoryRepo = new Lazy<ICardHistoryRepo>( () => new CardHistoryRepo(_repoContext));
        _playerRepo = new Lazy<IPlayerRepo>(() => new PlayerRepo(_repoContext));
    }
    
    public ICardRepo Cards => _cardRepo.Value;

    public ICardHistoryRepo PlayerCardHistory => _playerCardHistoryRepo.Value;

    public IPlayerRepo Players => _playerRepo.Value;

    public void Save() => _repoContext.SaveChanges();
    
}
