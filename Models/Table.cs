using Domain;
using ServiceContracts;

namespace Models;

/// <summary>
/// A type of card game model
/// </summary>
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

    /// <summary>
    /// Generate a new card list for CardStack
    /// </summary>
    public void GenerateStack() => CardStack.GenerateStack();

    /// <summary>
    /// Take a set of cards from CardStack
    /// </summary>
    /// <param name="count"></param>
    /// <returns>The taken cards</returns>
    public List<Card> Take(int count = 1)
    {
        if (CardStack.Cards.Count < count)
            Reset();
        if (CardStack.Cards.Count < count)
            return new List<Card>();

        return CardStack.TakeFrom(count);
    }

    /// <summary>
    /// Return a card that have been used by a player deck
    /// </summary>
    /// <param name="usedCard"></param>
    public void Used(Card usedCard) => UsedCardsStack.AddTo(usedCard);

    /// <summary>
    /// Move all used cards back to CardStack and shuffle the stack
    /// </summary>
    private void Reset()
    {
        CardStack.Cards = CardStack.Cards.Concat(UsedCardsStack.Cards).ToList();
        CardStack.Shuffle();
        UsedCardsStack.Cards.Clear(); 
    }
}
