using Models;

namespace IDAL.Data;

public interface IPlayerdata
{
    Task DeletePlayer(int id);
    Task<IEnumerable<Player>> GetPlayer();
    Task<Player> GetPlayer(int id);
    Task InsertPlayer(Player player);
    Task UpdatePlayer(Player player);
}