using Models;

namespace BLL.collection
{
    public interface IGameCollection
    {
        Task DeleteGame(int id);
        Task<List<Game>> GetAllGames();
        Task<Game> GetGame(int id);
        Task<Game> GetGameByName(string name);
        Task InsertGame(Game Game);
        Task UpdateGame(Game Game);
    }
}