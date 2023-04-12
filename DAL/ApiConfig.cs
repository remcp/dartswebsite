//namespace DAL
//{
//    public static class DALConfig
//    {
//        public static void ConfigureApi(this WebApplication app)
//        {
//            app.MapGet(pattern: "/Users", GetUsers);
//            app.MapGet(pattern: "/Users/{id}", GetUser);
//            app.MapPost(pattern: "/Users", InsertUser);
//        }

//        public static async Task<IResult> GetUsers(IPlayerdata data)
//        {
//            return Results.Ok(await data.GetUsers());
//        }

//        public static async Task<IResult> GetUser(IPlayerdata data, int id)
//        {
//            var results = Results.Ok(await data.GetUser(id));
//            return results;
//        }

//        public static async Task<IResult> InsertUser(IPlayerdata data, PlayerModel player)
//        {
//            await data.InsertPlayer(player);
//            return Results.Ok();
//        }
//    }
//}
