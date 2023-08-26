using AutoMapper;
using LojaAPI.Models.Cliente;
using LojaServicos.Dtos.Clientes;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("/clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServico clienteServico, IMapper mapper)
        {
            _clienteServico = clienteServico;
            _mapper = mapper;
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
