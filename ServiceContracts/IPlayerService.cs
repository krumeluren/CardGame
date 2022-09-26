
using Domain;

namespace ServiceContracts;

public interface IPlayerService
{
    public void AddCardHistory(string playerName, Card card);

    public List<CardHistory> GetAllHistory(string playerName);

}
