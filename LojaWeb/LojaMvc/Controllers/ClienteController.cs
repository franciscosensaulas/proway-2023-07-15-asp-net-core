using LojaRepositorios.Entidades;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaMvc.Controllers
{
    [Route("/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string? pesquisa)
        {
            var clientes = _clienteServico.ObterTodos(pesquisa);

            ViewBag.Clientes = clientes;
            ViewBag.Pesquisa = pesquisa;

            return View();
        }

        [Route("cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] string nome,
            [FromForm] string cpf,
            [FromForm] DateTime dataNascimento,
            [FromForm] string estado,
            [FromForm] string cidade,
            [FromForm] string bairro,
            [FromForm] string cep,
            [FromForm] string logradouro,
            [FromForm] string numero,
            [FromForm] string? complemento
            )
        {
            var cliente = new Cliente
            {
                Nome = nome.Trim(),
                Cpf = cpf.Trim(),
                DataNascimento = dataNascimento,
                Endereco = new Endereco
                {
                    Estado = estado,
                    Cidade = cidade,
                    Bairro = bairro,
                    Cep = cep,
                    Logradouro = logradouro, 
                    Numero = numero,
                    Complemento = complemento
                }
            };

            _clienteServico.Cadastrar(cliente);

            return RedirectToAction("Index");
        }
    }
}
