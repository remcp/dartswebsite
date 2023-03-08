using Api.DataAcces;

namespace Api.Data
{
    public class Playerdata : IPlayerdata
    {
        private readonly IDBaccess _db;
        public Playerdata(IDBaccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<PlayerModel>> GetUsers() => _db.LoadData<PlayerModel, dynamic>(storedprocedure: "[dbo].[getallplayers]", new { });

        public async Task<PlayerModel> GetUser(int id)
        {
            var results = await _db.LoadData<PlayerModel, dynamic>(storedprocedure: "dbo.getplayer", new { Id = id });

            return results.FirstOrDefault();
        }

        public Task InsertPlayer(PlayerModel player) => _db.Savedata(storedprocedure: "dbo.addplayer", parameters: new { player.playername, player.score });


        public Task UpdatePlayer(PlayerModel player) => _db.Savedata(storedprocedure: "dbo.updateplayer", new { playername = player.playername, score = player.score });

        public Task DeletePlayer(int id) => _db.Savedata(storedprocedure: "dbo.deleteplayer", new { Id = id });
    }
}
