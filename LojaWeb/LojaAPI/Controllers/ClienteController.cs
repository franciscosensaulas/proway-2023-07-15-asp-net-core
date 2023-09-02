using AutoMapper;
using LojaAPI.Filters;
using LojaAPI.Models.Cliente;
using LojaServicos.Dtos.Clientes;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [ServiceFilter(typeof(UsuarioAutenticadoFilter))]
    [Route("/api/clientes")]
    public class ClienteController : ControllerAuthenticatedBase
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico, IMapper mapper) : base(mapper)
        {
            _clienteServico = clienteServico;
        }

        // Obter todos
        [HttpGet]
        public IActionResult GetAll()
        {
            var clientes = _clienteServico.ObterTodos(string.Empty);

            return Ok(clientes);
        }


        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateModel model)
        {
            var clienteCadastrarDto = _mapper.Map<ClienteCadastrarDto>(model);

            _clienteServico.Cadastrar(clienteCadastrarDto);

            return Ok();
        }
    }
}
