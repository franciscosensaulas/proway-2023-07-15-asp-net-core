using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;

namespace LojaServicos.Servicos
{
    public class ProdutoServico
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        // Construtor
        public ProdutoServico()
        {
            // Instanciando o objeto da classe ProdutoRepositorio 
            _produtoRepositorio = new ProdutoRepositorio();
        }

        // CRUD
        public void Cadastrar(Produto produto)
        {
            _produtoRepositorio.Cadastrar(produto);
        }

        public List<Produto> ObterTodos(string pesquisa)
        {
            // Obter a lista de produtos da tabela de produtos
            var produtos = _produtoRepositorio.ObterTodos(pesquisa);
            // Retornar a lista de produtos
            return produtos;
        }

        public void Apagar(int id)
        {
            // Chamar o método Apagar do ProdutoRepositorio(que irá executar o DELETE)
            _produtoRepositorio.Apagar(id);
        }

        public Produto ObterPorId(int id)
        {
            var produto = _produtoRepositorio.ObterPorId(id);
            return produto;
        }

        public void Editar(Produto produto)
        {
            _produtoRepositorio.Editar(produto);
        }
    }
}
