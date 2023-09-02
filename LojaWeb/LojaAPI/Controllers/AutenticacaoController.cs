using AutoMapper;
using LojaAPI.Models.Autenticacao;
using LojaServicos.Dtos.Autenticacao;
using LojaServicos.Exceptions;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[Route("/api/autenticacao")]
public class AutenticacaoController : Controller
{
    private readonly IAutenticacaoServico _autenticacaoServico;
    private readonly IMapper _mapper;

    public AutenticacaoController(IAutenticacaoServico autenticacaoServico, IMapper mapper)
    {
        _autenticacaoServico = autenticacaoServico;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AutenticacaoModel autenticacaoModel)
    {
        try
        {
            var autenticacaoDto = _mapper.Map<AutenticarDto>(autenticacaoModel);
            _autenticacaoServico.Autenticar(autenticacaoDto, HttpContext.Session);
            return NoContent();
        }
        catch (UserNotFoundException)
        {
            return Unauthorized();
        }
    }
}