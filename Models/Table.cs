using Domain;
using ServiceContracts;

namespace Models;

public class Table
{
    public IServiceManager service { get; set; }
    public CardStack CardStack { get; set; }
    public CardStack UsedCardsStack { get; set; }    

    public Table(IServiceManager serviceManager)
    {
        service = serviceManager;
        CardStack = new CardStack(service);
        UsedCardsStack = new CardStack(service);
    }

    public void GenerateStack() => CardStack.GenerateStack();

    public List<Card> Take(int count = 1)
    {
        if (CardStack.Cards.Count < count)
            Reset();

        return CardStack.Take(count);
    }
    
    public void Used(Card usedCard) => UsedCardsStack.AddTo(usedCard);

    private void Reset()
    {
        CardStack.Cards = UsedCardsStack.Cards;
        CardStack.Shuffle();
        UsedCardsStack.Cards.Clear(); 
    }
}
