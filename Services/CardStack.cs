using Domain;
using RepositoryContracts;
using ServiceContracts;

namespace Services;

public class CardStack : ICardStack
{
    private readonly IRepoManager _repoManager;


    public CardStack(IRepoManager repoManager)
    {
        _repoManager = repoManager;
    }

    public List<Card> GenerateStack() => _repoManager.Cards.GetAll().ToList();

    public List<Card> Shuffle(List<Card> cards)
    {
        var random = new Random();
        return cards.OrderBy(x => random.Next()).ToList();
    }

    public List<Card> Take(List<Card> cards, int count = 1)
    {
        var cardsToTake = new List<Card>();
            
        for (int i = 0; i < count; i++)
        {
            var card = cards[cards.Count - 1];
            if (cards.Remove(card))
                cardsToTake.Add(card);
        }
        return cardsToTake;
    }
}
