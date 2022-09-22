
using Domain;

namespace ServiceContracts;

public interface ICardService
{
    IEnumerable<Card> GetAll();
}
