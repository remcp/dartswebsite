﻿using System.Numerics;
using DAL.Data;
using IBLL.Collections;
using IDAL.Data;
using Models;

namespace BLL.collection
{
    public class GameCollection : IGameCollection
    {
        private readonly IGamedata _data;

        public GameCollection(IGamedata data)
        {
            _data = data;
        }

        public async Task<List<Game>> GetAllGames()
        {
            var Games = await _data.GetGame();
            return Games.ToList();
        }

        public async Task<Game> GetGame(int id)
        {
            return await _data.GetGame(id);
        }

        public async Task<Game> GetGameByName(string name)
        {
            return await _data.GetGameByName(name);
        }

        public async Task InsertGame(Game Game)
        {
            await _data.InsertGame(Game);
        }

        public async Task UpdateGame(Game Game)
        {
            await _data.UpdateGame(Game);
        }

        public async Task InsertPlayer(int gameid, Player player)
        {
            await _data.InsertPlayer(gameid, player);
        }
        public async Task<IEnumerable<Models.Player>> GetPlayersActiveGame(int id)
        {
            return await _data.GetPlayersActiveGame(id);
        }
        public async Task DeleteActiveGame(int gameid)
        {
            await _data.DeleteActiveGame(gameid);
        }

        public async Task DeleteGame(int id)
        {
            await _data.DeleteGame(id);
        }
    }
}