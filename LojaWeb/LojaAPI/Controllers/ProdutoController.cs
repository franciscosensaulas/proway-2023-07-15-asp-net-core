using FluentValidation;
using FluentValidation.Results;
using LojaAPI.Validators;
using LojaRepositorios.Entidades;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Exceptions;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IValidator<ProdutoCreateModel> _produtoValidator;
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(
            IValidator<ProdutoCreateModel> produtoValidator,
            IProdutoServico produtoServico)
        {
            _produtoValidator = produtoValidator;
            _produtoServico = produtoServico;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _produtoServico.ObterTodos(string.Empty);

            return Ok(produtos);
        }

        //[HttpGet]
        //public IActionResult GetAll() =>
        //    Ok(_produtoServico.ObterTodos(string.Empty));


        // Obter o produto por id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoServico.ObterPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // /produtos
        [HttpPost]
        public IActionResult Create([FromBody] ProdutoCreateModel produtoCreateModel)
        {
            var validacao = _produtoValidator.Validate(produtoCreateModel);

            if (!validacao.IsValid)
            {

                // HTTP STATUS 422
                var erroDetalhes = ObterDadosDaValidacao(validacao.Errors);
                return UnprocessableEntity(erroDetalhes);
            }

            var dto = new ProdutoCadastrarDto
            {
                Nome = produtoCreateModel.Nome.Trim(),
                PrecoUnitario = produtoCreateModel.PrecoUnitario,
                Quantidade = produtoCreateModel.Quantidade
            };
            _produtoServico.Cadastrar(dto);

            return Ok();
        }

        // /produtos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _produtoServico.Apagar(id);

            return Ok();
        }

        // Alterar os dados de um produto
        // /produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoUpdateModel produtoUpdateModel)
        {
            var dto = new ProdutoEditarDto
            {
                Id = id,
                Nome = produtoUpdateModel.Nome.Trim(),
                PrecoUnitario = produtoUpdateModel.PrecoUnitario,
                Quantidade = produtoUpdateModel.Quantidade
            };

            try
            {
                _produtoServico.Editar(dto);

                return Ok();
            }
            catch (EntidadeNaoEncontrada)
            {
                return NotFound();
            }
        }

        private List<object> ObterDadosDaValidacao(List<ValidationFailure> errors)
        {
            var dados = new List<object>();


            foreach (var error in errors)
            {
                var errorDetail = new
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                };
                dados.Add(errorDetail);
            }

            return dados;
        }
    }

    public class ProdutoUpdateModel
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }

    public class ProdutoCreateModel
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
