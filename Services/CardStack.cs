using Domain;
using RepositoryContracts;
using ServiceContracts;

namespace Services;

public class CardStack : ICardStack
{
    private readonly IRepoManager _repoManager;

    public List<Card> Cards { get; set; } = new List<Card>();

    public CardStack(IRepoManager repoManager)
    {
        _repoManager = repoManager;
    }

    public void GenerateStack()
    {
        Cards = _repoManager.Cards.GetAll().ToList();
    }

    public void Shuffle()
    {
        var random = new Random();
        Cards = Cards.OrderBy(x => random.Next()).ToList();
    }

    public List<Card> Take(int count = 1)
    {
        var cardsToTake = new List<Card>();
        EnoughCardsLeft(count);
        
        for (int i = 0; i < count; i++)
        {
            var card = Cards[Cards.Count - 1];
            if (Cards.Remove(card))
                cardsToTake.Add(card);
        }
        return cardsToTake;
    }

    public void EnoughCardsLeft(int count)
    {
        if (Cards.Count < count)
            GenerateStack();
            Shuffle();
    }

}
