using IDAL.Data;

namespace DAL;

public static class ApiConfig
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet(pattern: "/Players", GetPlayers);
        app.MapGet(pattern: "/Players/{id}", GetPlayer);
        app.MapGet(pattern: "/Players/name/{name}", GetPlayerByName);
        app.MapPost(pattern: "/Players", InsertPlayer);
        app.MapPut(pattern: "/Players", UpdatePlayer);
        app.MapDelete(pattern: "/Players/{id}", DeletePlayer);
    }

    //Players
    private static async Task<IResult> GetPlayers(IPlayerdata data)
    {
        return Results.Ok(await data.GetPlayer());
    }

    private static async Task<IResult> GetPlayer(IPlayerdata data, int id)
    {
        var results = Results.Ok(await data.GetPlayer(id));
        return results;
    }
    private static async Task<IResult> GetPlayerByName(IPlayerdata data, string name)
    {
        var results = Results.Ok(await data.GetPlayerByName(name));
        return results;
    }

    private static async Task<IResult> InsertPlayer(IPlayerdata data, Models.Player Player)
    {
        await data.InsertPlayer(Player);
        return Results.Ok();
    }

    private static async Task<IResult> UpdatePlayer(IPlayerdata data, Models.Player Player)
    {
        await data.UpdatePlayer(Player);
        return Results.Ok();
    }

    private static async Task<IResult> DeletePlayer(IPlayerdata data, int id)
    {
        await data.DeletePlayer(id);
        return Results.Ok();
    }
}