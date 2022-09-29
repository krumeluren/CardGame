using Domain;

namespace ServiceContracts;

public interface ICardStackService
{
    /// <summary>
    /// Generate a stack of cards
    /// </summary>
    /// <returns>Generated stack of cards</returns>
    List<Card> GenerateStack();
    /// <summary>
    /// Return n cards from the end of the list
    /// </summary>
    /// <param name="cards">The stack of cards to return from</param>
    /// <param name="count">The amount of cards to return</param>
    /// <returns>A new list of cards from the end of the input list</returns>
    List<Card> GetLastCards(List<Card> cards, int count = 1);
}