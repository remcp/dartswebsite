using Models;

namespace IDAL.Data;

public interface IPlayerdata
{
    Task DeletePlayer(int id);
    Task<IEnumerable<Player>> GetPlayer();

    Task<Models.Player> GetPlayerByName(string name);
    Task<Player> GetPlayer(int id);
    Task InsertPlayer(Player player);
    Task UpdatePlayer(Player player);
    Task UpdateScore(Player player);
}