using LojaRepositorios.Database;
using LojaRepositorios.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaRepositorios.DependecyInjections
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRepositoryDependecyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddDatabaseSqlServer(configuration);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            return services;
        }

        private static IServiceCollection AddDatabaseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerArquivo");

            services.AddDbContext<LojaContexto>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
