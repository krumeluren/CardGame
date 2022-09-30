
using Domain;

namespace ServiceContracts;

/// <summary>
/// Common logic and data access for players.
/// </summary>
public interface IPlayerService
{
    /// <summary>
    /// Add a CardHistory to the player in the database.
    /// </summary>
    void AddCardHistory(string playerName, Card card);

    /// <summary>
    /// Get all CardHistory entities related to the player
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns>A list of CardHistory or empty if no player found</returns>
    List<CardHistory> GetAllHistory(string playerName);

    /// <summary>
    /// Search for a player in the database
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns>A player found in the database</returns>
    Player? GetPlayerByName(string playerName);

    /// <summary>
    /// Create and save a player entity to the database
    /// </summary>
    /// <param name="player"></param>
    void CreatePlayer(Player player);
}
