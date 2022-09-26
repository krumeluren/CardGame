using Domain;
using ServiceContracts;


namespace CardGame.Data;

public class MinigameCardStack
{
    public List<Card> Cards { get; set; } = new List<Card>();

    public List<Card> UsedCards { get; set; } = new List<Card>();

    public IServiceManager service { get; set; }

    public MinigameCardStack(IServiceManager serviceManager)
    {
        service = serviceManager;
    }
    public void GenerateStack()
    {
        Cards = service.CardStackService.GenerateStack();
        //TODO: remove. used for testing
        Cards.RemoveRange(0, 40);
    }
    
    public void Shuffle()
    {
        Cards = service.CardStackService.Shuffle(Cards);
    }

    public List<Card> Take(int count = 1)
    {
        if (Cards.Count < count)
            Reset();
        
        return service.CardStackService.Take(Cards, count);
    }

    public void Used(Card usedCard)
    {
        UsedCards.Add(usedCard);
    }

    public void Reset()
    {
        Cards = UsedCards;
        UsedCards = new List<Card>();
        Shuffle();
    }
}
