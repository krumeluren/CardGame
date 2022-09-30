using Domain;
using ServiceContracts;

namespace Models;

public interface ICardStack
{
    /// <summary>
    /// List of cards in the stack
    /// </summary>
    List<Card> Cards { get; set; }
    
    /// <summary>
    /// The service manager
    /// </summary>
    IServiceManager service { get; set; }
    
    /// <summary>
    /// Add a card back to the stack after use
    /// </summary>
    void AddTo(Card usedCard);
    
    /// <summary>
    /// Get a type of card stack from the service and add it to Cards.
    /// </summary>
    void GenerateStack();
    
    /// <summary>
    /// Randomise the Cards list
    /// </summary>
    void Shuffle();

    /// <summary>
    /// Take and remove cards from Cards
    /// </summary>
    /// <returns>A set of taken cards</returns>
    List<Card> TakeFrom(int count = 1);
}