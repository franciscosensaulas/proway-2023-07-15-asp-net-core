using LojaServicos.Dtos.Autenticacao;
using Microsoft.AspNetCore.Http;

namespace LojaServicos.Servicos;

public interface IAutenticacaoServico
{
    void Autenticar(AutenticarDto autenticarDto, ISession session);
    void Sair(ISession httpContextSession);
}