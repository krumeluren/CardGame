
using Domain;

namespace RepositoryContracts;

public interface ICardHistoryRepo
{
    void Add(CardHistory cardHistory);
    IEnumerable<CardHistory> GetAll();
}
