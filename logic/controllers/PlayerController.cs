using Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic.controllers
{
    internal class PlayerController
    {
        public async Task<List<Models.PlayerModel>> GetAllplayers(IPlayerdata data)
        {
            List<Api.PlayerModel> entitylist = new List<Api.PlayerModel>();

            entitylist = (List<Api.PlayerModel>)await data.GetUsers();

            List<Models.PlayerModel> playerlist = new List<Models.PlayerModel>();

            foreach (Api.PlayerModel player in entitylist)
            {
                playerlist.Add(new Api.PlayerModel(player));
            }

            return playerlist;
        }

        public async Task<Api.PlayerModel> Getplayer(IPlayerdata data, int id)
        {
            return new Api.PlayerModel(await data.GetUser(id));
        }

        public async Task Insertplayer(IPlayerdata data, Api.PlayerModel player)
        {
            Api.PlayerModel insertplayer = new Api.PlayerModel()
            {
                playername = player.playername,
                score= player.score,
            };

            await data.InsertPlayer(insertplayer);
        }

        public async Task Updateplayer(IPlayerdata data, Api.PlayerModel player)
        {
            Api.PlayerModel updateplayer = new Api.PlayerModel()
            {
                id = player.id,
                playername = player.playername,
                score = player.score,
            };

            await data.UpdatePlayer(updateplayer);
        }

        public async Task UpdatePassword(IPlayerdata data, Api.PlayerModel player)
        {
            Api.PlayerModel updateplayer = new Api.PlayerModel()
            {
                id = player.id,
                score = player.score,
            };

            await data.UpdatePlayer(updateplayer);
        }

        public async Task Deleteplayer(IPlayerdata data, int id)
        {
            await data.DeletePlayer(id);
        }
    }
}
