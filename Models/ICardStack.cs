using Domain;
using ServiceContracts;

namespace Models
{
    public interface ICardStack
    {
        List<Card> Cards { get; set; }
        IServiceManager service { get; set; }

        void AddTo(Card usedCard);
        void GenerateStack();
        void Shuffle();
        List<Card> TakeFrom(int count = 1);
    }
}