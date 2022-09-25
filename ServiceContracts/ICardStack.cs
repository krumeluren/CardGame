using Domain;

namespace ServiceContracts;

public interface ICardStack
{
    /// <summary>
    /// Generate a stack of cards
    /// </summary>
    /// <returns>Generated stack of cards</returns>
    List<Card> GenerateStack();
    /// <summary>
    /// Take n cards from the param list
    /// </summary>
    /// <param name="cards">The stack of cards to take from</param>
    /// <param name="count">The amount of cards to take</param>
    /// <returns>A list of cards</returns>
    List<Card> Take(List<Card> cards, int count = 1);

    /// <summary>
    /// A method of shuffling the cards list
    /// </summary>
    /// <param name="cards">The list to be shuffled</param>
    /// <returns>A shuffled list of the param list</returns>
    List<Card> Shuffle(List<Card> cards);
    
}