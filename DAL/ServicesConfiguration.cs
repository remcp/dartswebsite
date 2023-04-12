using DAL.Context;
using DAL.DataAcces;
using IDAL.Data;
using IDAL.DbAccess;
using DAL.Data;

namespace Seathub.DAL;

public static class ServicesConfiguration
{
    public static void AddDataServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(typeof(Program).Assembly);
        services.AddSingleton<DapperContext>();
        services.AddSingleton<IDbAccess, Dbaccess>();
        services.AddSingleton<IPlayerdata, Playerdata>();
    }
}