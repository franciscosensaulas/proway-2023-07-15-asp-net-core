using LojaServicos.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace LojaServicos.DependencyInjections
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();

            return services;
        }
    }
}
