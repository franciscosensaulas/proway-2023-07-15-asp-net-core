using LojaMvc.Models.Cliente;
using LojaRepositorios.Entidades;
using LojaServicos.Dtos.Clientes;
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
            var dtos = _clienteServico.ObterTodos(pesquisa);

            var viewModel = ConstruirClienteIndexViewModel(dtos, pesquisa);

            return View(viewModel);
        }

        private ClienteIndexViewModel ConstruirClienteIndexViewModel(List<ClienteIndexDto> dtos, string? pesquisa)
        {
            return new ClienteIndexViewModel
            {
                Pesquisa = pesquisa,
                Clientes = ConstruirClienteViewModel(dtos)
            };
        }

        private List<ClienteViewModel> ConstruirClienteViewModel(List<ClienteIndexDto> dtos)
        {
            var viewModels = new List<ClienteViewModel>();
            foreach (var dto in dtos)
            {
                viewModels.Add(new ClienteViewModel
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Cpf = dto.Cpf,
                    Endereco = dto.Endereco
                });
            }
            return viewModels;
        }

        [Route("cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var viewModel = new ClienteCadastroViewModel();

            return View(viewModel);
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromForm] ClienteCadastroViewModel clienteCadastro)
        {
            if (ModelState.IsValid == false)
            {
                return View("Cadastrar", clienteCadastro);
            }

            var clienteCadatrarDto = ConstruirClienteCadastrarDto(clienteCadastro);

            _clienteServico.Cadastrar(clienteCadatrarDto);

            return RedirectToAction("Index");
        }

        public ClienteCadastrarDto ConstruirClienteCadastrarDto(
            ClienteCadastroViewModel viewModel)
        {
            return new ClienteCadastrarDto
            {
                Nome = viewModel.Nome.Trim(),
                Cpf = viewModel.Cpf.Trim(),
                DataNascimento = viewModel.DataNascimento.GetValueOrDefault(),
                Estado = viewModel.Estado,
                Cidade = viewModel.Cidade,
                Bairro = viewModel.Bairro,
                Cep = viewModel.Cep,
                Logradouro = viewModel.Logradouro,
                Numero = viewModel.Numero,
                Complemento = viewModel.Complemento
            };
        }
    }
}
