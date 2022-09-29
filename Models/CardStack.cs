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
    }

    public void Shuffle() 
    {
        var random = new Random();
        Cards = Cards.OrderBy(x => random.Next()).ToList();
    }

    public List<Card> TakeFrom(int count = 1)
    {
        if (Cards.Count < count)
            return new List<Card>();
        var returnedCards =  service.CardStackService.GetLastCards(Cards, count);
        Cards = Cards.Except(returnedCards).ToList();
        return returnedCards;
    }
    
    public void AddTo(Card usedCard) => Cards.Add(usedCard);
}
