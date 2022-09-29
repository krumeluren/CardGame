using Domain;
using RepositoryContracts;
using ServiceContracts;

namespace Services;

public class CardStackService : ICardStackService
{
    private readonly IRepoManager _repoManager;

    public CardStackService(IRepoManager repoManager)
    {
        _repoManager = repoManager;
    }

    public List<Card> GenerateStack() => _repoManager.Cards.GetAll().ToList();

    public List<Card> Shuffle(List<Card> cards)
    {
        var random = new Random();
        return cards.OrderBy(x => random.Next()).ToList();
    }

    public List<Card> GetLastCards(List<Card> cards, int count = 1)
    {
        var inputCards = cards.ToList();  //Clone reference list to not modify original
        var cardsToTake = new List<Card>();

        if (inputCards.Count < count)
            return cardsToTake;
        
        for (int i = 0; i < count; i++)
        {
            var card = inputCards.Last();
            if (inputCards.Remove(card))
                cardsToTake.Add(card);
        }
        
        return cardsToTake;
    }
}
