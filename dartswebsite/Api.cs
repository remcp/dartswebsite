using models;
using models.Data;

namespace dartswebsite
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet(pattern: "/Users", GetUsers);
            app.MapGet(pattern: "/Users/{id}", GetUser);
            app.MapPost(pattern: "/Users", InsertUser);
        }

        public static async Task<IResult> GetUsers(IPlayerData data)
        {
            return Results.Ok( await data.GetUsers());
        }

        public static async Task<IResult> GetUser(IPlayerData data, int id)
        {
            var results = Results.Ok(await data.GetUser(id));
            return results;
        }

        public static async Task<IResult> InsertUser(IPlayerData data, PlayerModel player)
        {
            await data.InsertPlayer(player);
            return Results.Ok();
        }
    }
}
