using AutoMapper;
using LojaAPI.Mappers;
using LojaAPI.Models.Cliente;
using LojaAPI.Models.Produto;
using LojaServicos.Dtos.Clientes;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Mappers;

namespace LojaAPI.DependencyInjections
{
    public static class ApiAutoMapperDependencyInjection
    {
        public static IServiceCollection AddApiAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<ClienteCreateModel, ClienteCadastrarDto>();
                x.CreateMap<ProdutoCreateModel, ProdutoCadastrarDto>();
                x.CreateMap<ProdutoUpdateModel, ProdutoEditarDto>();
                x.AddProfile<ClienteMapper>();
                x.AddProfile<AutenticarMapper>();
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
