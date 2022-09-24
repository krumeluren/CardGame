using Domain;

namespace ServiceContracts;

public interface ICardStack
{
    List<Card> Cards { get; set; }
    void GenerateStack();
    List<Card> Take(int count = 1);
    void Shuffle();
    
}