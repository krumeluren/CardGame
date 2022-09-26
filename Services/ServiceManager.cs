using RepositoryContracts;
using ServiceContracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{

    private readonly CardStack _cardStackService;
    
    private readonly PlayerService _playerService;

    public ServiceManager(IRepoManager repoManager)
	{
        _cardStackService = new CardStack(repoManager);
        _playerService = new PlayerService(repoManager);
    }

    public ICardStack CardStackService => _cardStackService;

    public IPlayerService PlayerService => _playerService;
}
