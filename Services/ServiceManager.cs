using RepositoryContracts;
using ServiceContracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{

    private readonly CardStackService _cardStackService;

    private readonly PlayerService _playerService;

    public ServiceManager(IRepoManager repoManager)
    {
        _cardStackService = new CardStackService(repoManager);
        _playerService = new PlayerService(repoManager);
    }

    public ICardStackService CardStackService => _cardStackService;

    public IPlayerService PlayerService => _playerService;
}
