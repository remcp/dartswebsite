using BLL.collection;
using IBLL.Collections;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class ServicesConfiguration
{
    public static void AddLogicServices(this IServiceCollection services)
    {
        services.AddSingleton<IPlayerCollection, PlayerCollection>();
    }
}