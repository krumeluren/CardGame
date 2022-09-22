using RepositoryContracts;
using ServiceContracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
	private readonly CardService _cardService;

    public ServiceManager(IRepoManager repoManager)
	{
        _cardService = new CardService(repoManager);
    }

    public ICardService CardService => _cardService;
}
