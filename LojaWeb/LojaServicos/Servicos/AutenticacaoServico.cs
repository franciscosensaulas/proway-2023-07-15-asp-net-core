using System.Text.Json;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Autenticacao;
using LojaServicos.Exceptions;
using Microsoft.AspNetCore.Http;

namespace LojaServicos.Servicos;

public class AutenticacaoServico : IAutenticacaoServico
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public AutenticacaoServico(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public void Autenticar(AutenticarDto autenticarDto, ISession session)
    {
        var usuario = _usuarioRepositorio.GetByEmailAndPassword(
            autenticarDto.Email, autenticarDto.Senha);

        if (usuario == null)
        {
            throw new UserNotFoundException();
        }

        var usuarioJson = JsonSerializer.Serialize(usuario);
        session.SetString("usuarioSessao" ,usuarioJson);
    }

    public void Sair(ISession session)
    {
        var usuarioDaSessao = session.GetString("usuarioSessao");
        if (usuarioDaSessao != null)
            session.Remove("usuarioSessao");
    }
}