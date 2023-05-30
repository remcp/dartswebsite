using IBLL.Collections;
using IDAL.Data;
using Models;

namespace BLL.collection
{
    public class PlayerCollection : IPlayerCollection
    {
        private readonly IPlayerdata _data;

        public PlayerCollection(IPlayerdata data)
        {
            _data = data;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            var Players = await _data.GetPlayer();
            return Players.ToList();
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await _data.GetPlayer(id);
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            return await _data.GetPlayerByName(name);
        }

        public async Task InsertPlayer(Player Player)
        {
            await _data.InsertPlayer(Player);
        }

        public async Task UpdatePlayer(Player Player)
        {
            await _data.UpdatePlayer(Player);
        }

        public async Task DeletePlayer(int id)
        {
            await _data.DeletePlayer(id);
        }

        public async Task<bool> CheckCredentials(string name, string password)
        {
            Player player = new Player();
            try
            {
                player = await _data.GetPlayerByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Player does not exist");
            }

            if (player.playerpwd == password)
            {
                return true;
            }
            else
            {
                throw new Exception("foute inloggegevens");
            }
        }
    }
}
