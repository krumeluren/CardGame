using Domain;
using RepositoryContracts;
using ServiceContracts;

namespace Services;

public class PlayerService : IPlayerService
{

    private readonly IRepoManager _repoManager;

    public PlayerService(IRepoManager repoManager)
    {
        _repoManager = repoManager;
    }

    public void AddCardHistory(string playerName, Card card)
    {
        if (playerName is null)
            return;
        
        var player = _repoManager.Players.GetByName(playerName);
        
        if (player is null)
        {
            player = new Player();
            player.Name = playerName;
            CreatePlayer(player);
        }              

        _repoManager.PlayerCardHistory.Add(new CardHistory() { CardId = card.Id, PlayerId = player.Id });
        _repoManager.Save();
    }

    public void CreatePlayer(Player player)
    {
        _repoManager.Players.Add(player);
        _repoManager.Save();
    }

    public List<CardHistory> GetAllHistory(string playerName)
    {
        var player = _repoManager.Players.GetByName(playerName);
        if (player is null)
            return new List<CardHistory>();

        return _repoManager.PlayerCardHistory.GetAll().
            Where(x => x.PlayerId == player.Id).ToList();
    }

    public Player? GetPlayerByName(string playerName) =>
        _repoManager.Players.GetByName(playerName);
    
}
