﻿using AutoMapper;
using DAL.DataAcces;
using IDAL.Data;
using Models;
using IDbAccess = IDAL.DbAccess.IDbAccess;

namespace DAL.Data
{
    public class Playerdata : IPlayerdata
    {
        private readonly IDbAccess _db;
        private readonly IMapper _mapper;
        public Playerdata(IDbAccess db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Models.Player>> GetPlayer()
        {
            var Players = await _db.LoadData<PlayerModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_GetAll", new { });

            return Players.Select(p => _mapper.Map<Models.Player>(p));
        }

        public async Task<Models.Player> GetPlayer(int id)
        {
            var results = await _db.LoadData<Player, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.getplayer", new { Id = id });

            return _mapper.Map<Models.Player>(results.FirstOrDefault());
        }

        public Task InsertPlayer(Player player) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.addplayer", parameters: new { player.playername, player.score });


        public Task UpdatePlayer(Player player) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.updateplayer", new { playername = player.playername, score = player.score });

        public Task DeletePlayer(int id) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.deleteplayer", new { Id = id });
    }
}