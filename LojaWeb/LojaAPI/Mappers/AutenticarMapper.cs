using AutoMapper;
using LojaAPI.Models.Autenticacao;
using LojaRepositorios.ExtensionMethods;
using LojaServicos.Dtos.Autenticacao;

namespace LojaAPI.Mappers;

public class AutenticarMapper : Profile
{
    public AutenticarMapper()
    {
        CreateMap<AutenticacaoModel, AutenticarDto>()
            .ForMember(x => x.Senha, opt => opt.MapFrom(y => y.Senha.Hash512()));
    }
}