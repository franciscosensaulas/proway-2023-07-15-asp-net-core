using LojaRepositorios.Entidades;
using Microsoft.AspNetCore.Mvc;
using WindowsFormsExemplos.Servicos;

namespace LojaMvc.Controllers
{
    [Route("/cliente")]
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var clienteServico = new ClienteServico();
            var clientes = clienteServico.ObterTodos();

            ViewBag.Clientes = clientes;
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

            var clienteServico = new ClienteServico();
            clienteServico.Cadastrar(cliente);

            return RedirectToAction("Index");
        }
    }
}
