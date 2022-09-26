
using Domain;

namespace RepositoryContracts;

public interface ICardHistoryRepo
{
    public void Add(CardHistory cardHistory);

    public IEnumerable<CardHistory> GetAll();
}
