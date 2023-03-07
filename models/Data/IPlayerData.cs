namespace models.Data
{
    public interface IPlayerData
    {
        Task DeletePlayer(int id);
        Task<PlayerModel?> GetUser(int id);
        Task<IEnumerable<PlayerModel>> GetUsers();
        Task InsertPlayer(PlayerModel player);
        Task UpdatePlayer(PlayerModel player);
    }
}