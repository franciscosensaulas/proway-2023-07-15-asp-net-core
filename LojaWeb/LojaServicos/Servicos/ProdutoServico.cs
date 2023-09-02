using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Exceptions;
using System.ComponentModel;

namespace LojaServicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        // Construtor
        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public int Cadastrar(ProdutoCadastrarDto dto)
        {
            var produto = ConstruirProduto(dto);

            produto = _produtoRepositorio.Add(produto);

            return produto.Id;
        }

        public List<ProdutoIndexDto> ObterTodos(string pesquisa)
        {
            // Obter a lista de produtos da tabela de produtos
            var produtos = _produtoRepositorio.ObterTodos(pesquisa);

            var produtoDtos = ConstruirProdutoIndexDtos(produtos);

            // Retornar a lista de produtos
            return produtoDtos;
        }

        public void Apagar(int id)
        {
            _produtoRepositorio.DeleteLogic(id);
        }

        public ProdutoIndexDto? ObterPorId(int id)
        {
            var produto = _produtoRepositorio.GetById(id);

            return produto == null ? null : ConstruirProdutoIndexDto(produto);
        }

        public void Editar(ProdutoEditarDto dto)
        {
            var produto = _produtoRepositorio.GetById(dto.Id);

            if (produto == null)
                throw new EntidadeNaoEncontrada();

            produto = AtualizarProduto(dto, produto);

            _produtoRepositorio.Update(produto);
        }

        private Produto AtualizarProduto(ProdutoEditarDto dto, Produto produto)
        {
            produto.Nome = dto.Nome;
            produto.PrecoUnitario = dto.PrecoUnitario;
            return produto;
        }

        private static Produto ConstruirProduto(ProdutoCadastrarDto dto)
        {
            return new Produto
            {
                Nome = dto.Nome,
                PrecoUnitario = dto.PrecoUnitario
            };
        }

        private List<ProdutoIndexDto> ConstruirProdutoIndexDtos(List<Produto> produtos)
        {
            return produtos
                .Select(x => ConstruirProdutoIndexDto(x))
                .ToList();
        }

        private ProdutoIndexDto ConstruirProdutoIndexDto(Produto produto)
        {
            return new ProdutoIndexDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                PrecoUnitario = produto.PrecoUnitario
            };
        }
    }
}