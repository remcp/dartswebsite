using DAL.DataAcces;
using IDAL.Data;
using Models;
using IDbAccess = IDAL.DbAccess.IDbAccess;

namespace DAL.Data
{
    public class Playerdata : IPlayerdata
    {
        private readonly IDbAccess _db;
        public Playerdata(IDbAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Player>> GetPlayer() => _db.LoadData<Player, dynamic>(storedprocedure: "[dbo].[getallplayers]", new { });

        public async Task<Player> GetPlayer(int id)
        {
            var results = await _db.LoadData<Player, dynamic>(storedprocedure: "dbo.getplayer", new { Id = id });

            return results.FirstOrDefault();
        }

        public Task InsertPlayer(Player player) => _db.Savedata(storedprocedure: "dbo.addplayer", parameters: new { player.playername, player.score });


        public Task UpdatePlayer(Player player) => _db.Savedata(storedprocedure: "dbo.updateplayer", new { playername = player.playername, score = player.score });

        public Task DeletePlayer(int id) => _db.Savedata(storedprocedure: "dbo.deleteplayer", new { Id = id });
    }
}
