using Domain;
using RepositoryContracts;
using ServiceContracts;

namespace Services;

public class CardService : ICardService
{
    public IRepoManager _repoManager { get; set; }
    public CardService(IRepoManager repoManager)
    {
        _repoManager = repoManager;
    }

    public IEnumerable<Card> GetAll() => _repoManager.Cards.GetAll();
    
}
