using AutoMapper;
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
            var Players = await _db.LoadData<PlayerModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_getall", new { });

            return Players.Select(p => _mapper.Map<Models.Player>(p));
        }

        public async Task<Models.Player> GetPlayer(int id)
        {
            var results = await _db.LoadData<Player, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_getplayer", new { Id = id });

            return _mapper.Map<Models.Player>(results.FirstOrDefault());
        }

        public async Task<Models.Player> GetPlayerByName(string name)
        {
            Models.Player modelplayer = new();
            try
            {
                var results = await _db.LoadData<PlayerModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_getplayerbyname", new { Iname = name });
                modelplayer = _mapper.Map<Models.Player>(results.FirstOrDefault());
            }
            catch
            {
                throw new Exception();
            }

            return modelplayer;
        }

        public Task InsertPlayer(Player player)
        {
            PlayerModel playerdto = _mapper.Map<PlayerModel>(player);

            _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_InsertPlayer", parameters: new { Iplayername = playerdto.Name,Iplayerpwd = playerdto.Password, Iscore = playerdto.Score });
            return Task.CompletedTask;
        }
        public Task UpdateScore(Player player)
        {
            PlayerModel playerdto = _mapper.Map<PlayerModel>(player);
            try
            {
                _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_UpdateScore", parameters: new { Iplayername = playerdto.Name, Iscore = player.score });
            }
            catch 
            {
                throw new Exception();
            }
                Player playermodel = _mapper.Map<Player>(player);
            return Task.CompletedTask;
        }

        public Task UpdatePlayer(Player player) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_updateplayer", new { playername = player.playername, score = player.score });

        public Task DeletePlayer(int id) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Players_deleteplayer", new { Id = id });
    }
}