using LojaServicos.Dtos.Clientes;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("/clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
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

        // Obter Cliente por Id
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var cliente = _clienteServico.ObterPorId(id);
        //    return Ok(cliente);
        //}

        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateModel model)
        {
            var clienteCadastrarDto = new ClienteCadastrarDto
            {
                Nome = model.Nome,
                Bairro = model.Bairro,
                Cep = model.Cep,
                Cidade = model.Cidade,
                Complemento = model.Complemento,
                Cpf = model.Cpf,
                Estado = model.Estado,
                Logradouro = model.Logradouro,
                DataNascimento = model.DataNascimento,
                Numero = model.Numero,
            };

            _clienteServico.Cadastrar(clienteCadastrarDto);

            return Ok();
        }
    }

    public class ClienteCreateModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
