using IBLL.Collections;
using IDAL.Data;
using Models;

namespace BLL.collection
{
    public class PlayerCollection : IPlayerCollection
    {
        private readonly IPlayerdata _data;
        CheckScore checkscore { get; set; }
        public PlayerCollection(IPlayerdata data)
        {
            _data = data;
            checkscore = new CheckScore();
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
                throw new Exception(ex.Message);
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

        public async Task<Player> UpdateScore(Player player, int input)
        {
            if (checkscore.LegalScore(input).Result == true)
            {
                player = player.UpdateScore(player, input);
            }

            await _data.UpdateScore(player);
            return player;
        }
        public async Task<Player> SetScore(Player player, int input)
        {
            player = player.SetScore(player, input);
            await _data.UpdateScore(player);
            return player;
        }

        public async Task<string> GetOutText(Player player)
        {
            string outtext = checkscore.canfinish(player.score).Result;
            return outtext;
        }
    }
}