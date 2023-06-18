using AutoMapper;
using DAL.DataAcces;
using IDAL.Data;
using Models;
using IDbAccess = IDAL.DbAccess.IDbAccess;

namespace DAL.Data
{
    public class Gamedata : IGamedata
    {
        private readonly IDbAccess _db;
        private readonly IMapper _mapper;
        public Gamedata(IDbAccess db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Models.Game>> GetGame()
        {
            var Games = await _db.LoadData<GameModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Games_GetAll", new { });

            return Games.Select(p => _mapper.Map<Models.Game>(p));
        }

        public async Task<Models.Game> GetGame(int id)
        {
            var results = await _db.LoadData<GameModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Games_getGame", new { Id = id });

            return _mapper.Map<Models.Game>(results.FirstOrDefault());
        }

        public async Task<Models.Game> GetGameByName(string name)
        {
            Models.Game modelGame = new();
            try
            {
                var results = await _db.LoadData<GameModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Games_getGamebyname", new { Iname = name });
                modelGame = _mapper.Map<Models.Game>(results.FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return modelGame;
        }

        public Task InsertGame(Game game)
        {
            GameModel gamedto = _mapper.Map<GameModel>(game);
            _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Games_addGame", parameters: new { gamedto.gamemode });
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<Models.Player>> GetPlayersActiveGame(int id)
        {
            var results = await _db.LoadData<PlayerModel, dynamic>(storedprocedure: "u156573p149336_bullseyebuddy.sp_Join_GetPlayersActiveGame", new { Igameid = id });

            return results.Select(p => _mapper.Map<Models.Player>(p));
        }

        public Task InsertPlayer(int gameid, Player player)
        {
            PlayerModel playerdto = _mapper.Map<PlayerModel>(player);
            GameModel gamedto = new();
            gamedto.Game_id = gameid;
            _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Join_InsertPlayer", parameters: new { Iplayerid = playerdto.Player_id, IGameid = gamedto.Game_id });
            return Task.CompletedTask;
        }
        public Task DeleteActiveGame(int gameid)
        {
            GameModel gamedto = new();
            gamedto.Game_id = gameid;
            _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Join_RemoveGamePlayers", parameters: new { IGameid = gamedto.Game_id});
            return Task.CompletedTask;
        }

        public Task UpdateGame(Game Game) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Games_updateGame", new { Gamename = Game.gamemode, score = Game.score });

        public Task DeleteGame(int id) => _db.Savedata(storedprocedure: "u156573p149336_bullseyebuddy.sp_Games_deleteGame", new { Id = id });
    }
}