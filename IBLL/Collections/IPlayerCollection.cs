using Models;

namespace IBLL.Collections;

public interface IPlayerCollection
{
    Task<List<Player>> GetAllPlayers();
    Task<Player> GetPlayer(int id);
    Task InsertPlayer(Player Player);
    Task UpdatePlayer(Player Player);
    Task DeletePlayer(int id);
}