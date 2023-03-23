using Api.Data;
namespace logic.controllers
{
    public class PlayerCollection
    {
        public List<Models.PlayerModel> models;
        readonly IPlayerdata _playerdata;
        public async Task<List<Models.PlayerModel>> GetAllplayers()
        {
            List<Api.PlayerModel> entitylist = new List<Api.PlayerModel>();

            entitylist = (List<Api.PlayerModel>)await _playerdata.GetUsers();

            List<Models.PlayerModel> playerlist = new List<Models.PlayerModel>();

            foreach (Api.PlayerModel player in entitylist)
            {
                playerlist.Add(new Models.PlayerModel(player));
            }
            models = playerlist;
            return playerlist;
        }

        public async Task<Models.PlayerModel> Getplayer(int id)
        {
            return  new Models.PlayerModel(await _playerdata.GetUser(id));
        }

        public async Task Insertplayer(Models.PlayerModel player)
        {
            Api.PlayerModel insertplayer = new Api.PlayerModel()
            {
                playername = player.playername,
                score= player.score,
            };

            await _playerdata.InsertPlayer(insertplayer);
            models.Add(player);
        }

        public async Task Updateplayer(logic.Models.PlayerModel player)
        {
            Api.PlayerModel updateplayer = new Api.PlayerModel()
            {
                id = player.id,
                playername = player.playername,
                score = player.score,
            };

            await _playerdata.UpdatePlayer(updateplayer);
        }

        public async Task UpdatePassword(Api.PlayerModel player)
        {
            Api.PlayerModel updateplayer = new Api.PlayerModel()
            {
                id = player.id,
                score = player.score,
            };

            await _playerdata.UpdatePlayer(updateplayer);
        }

        public async Task Deleteplayer(int id)
        {
            await _playerdata.DeletePlayer(id);
        }
    }
}
