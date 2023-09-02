using AutoMapper;
using LojaMvc.Models.Autenticacao;
using LojaRepositorios.ExtensionMethods;
using LojaServicos.Dtos.Autenticacao;

namespace LojaMvc.Mappers;

public class AutenticacaoMapper : Profile
{
    public AutenticacaoMapper()
    {
        CreateMap<AutenticacaoViewModel, AutenticarDto>()
            .ForMember(x => x.Senha, opt => opt.MapFrom(y => y.Senha.Hash512()));
    }
}