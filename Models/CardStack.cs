using Domain;
using ServiceContracts;

namespace Models;

public class CardStack
{
    public List<Card> Cards { get; set; } = new List<Card>();

    public IServiceManager service { get; set; }

    public CardStack(IServiceManager serviceManager)
    {
        service = serviceManager;
    }
    public void GenerateStack()
    {
        Cards = service.CardStackService.GenerateStack();
        //TODO: remove. used for testing
        Cards.RemoveRange(0, 40);
    }

    public void Shuffle() => Cards = service.CardStackService.Shuffle(Cards);

    public List<Card> Take(int count = 1)
    {
        if (Cards.Count < count)
            return new List<Card>();
        return service.CardStackService.Take(Cards, count);
    }
    
    public void AddTo(Card usedCard) => Cards.Add(usedCard);
}
