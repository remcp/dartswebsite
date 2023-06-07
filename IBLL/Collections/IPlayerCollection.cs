using Models;

namespace IBLL.Collections;

public interface IPlayerCollection
{
    Task<List<Player>> GetAllPlayers();
    Task<Player> GetPlayer(int id);

    Task<Player> GetPlayerByName(string name);
    Task InsertPlayer(Player Player);
    Task UpdatePlayer(Player Player);
    Task DeletePlayer(int id);
    Task<bool> CheckCredentials(string name, string password);

    Task<Player> UpdateScore(Player player, int input);
    Task<Player> SetScore(Player player, int input);

    Task<string> GetOutText(Player player);
}