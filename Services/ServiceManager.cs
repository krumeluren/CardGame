using RepositoryContracts;
using ServiceContracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{

    private readonly CardStack _cardStackService;

    public ServiceManager(IRepoManager repoManager)
	{
        _cardStackService = new CardStack(repoManager);
    }

    public ICardStack CardStackService => _cardStackService;
}
