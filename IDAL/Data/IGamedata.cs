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
        Task UpdateGame(Game Game);
    }
}