using Domain;

namespace RepositoryContracts;

public interface ICardRepo
{
    IEnumerable<Card> GetAll();
}
