
using Domain;

namespace ServiceContracts;

public interface IPlayerService
{
    void AddCardHistory(string playerName, Card card);

    List<CardHistory> GetAllHistory(string playerName);

    Player? GetPlayerByName(string playerName);

    void CreatePlayer(Player player);
}
