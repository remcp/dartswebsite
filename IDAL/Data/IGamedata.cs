using Models;

namespace DAL.Data
{
    public interface IGamedata
    {
        Task DeleteGame(int id);
        Task<IEnumerable<Game>> GetGame();
        Task<Game> GetGame(int id);
        Task<Game> GetGameByName(string name);
        Task InsertGame(Game Game);

        Task InsertPlayer(int gameid, Player player);
        Task<IEnumerable<Models.Player>> GetPlayersActiveGame(int id);
        Task DeleteActiveGame(int gameid);
        Task UpdateGame(Game Game);
    }
}