using LojaAPI.Filters;

namespace LojaAPI.DependencyInjections;

public static class LojaAutenticacaoDependecyInjection
{
    public static IServiceCollection AddLojaAutentication(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        
        services.AddScoped<UsuarioAutenticadoFilter>();
        
        return services;
    }
}
