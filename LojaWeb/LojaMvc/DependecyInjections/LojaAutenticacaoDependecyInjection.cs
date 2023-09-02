namespace LojaMvc.DependecyInjections;

public static class LojaAutenticacaoDependecyInjection
{
    public static IServiceCollection AddLojaAutentication(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        
        return services;
    }
}
