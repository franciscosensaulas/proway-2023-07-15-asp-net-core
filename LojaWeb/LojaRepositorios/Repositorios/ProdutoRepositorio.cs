using LojaRepositorios.Database;
using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        // Construtor: é executado quando ocorre um new da classe, ou seja,
        // new ProdutoRepositorio() irá executar o contrutor
        public ProdutoRepositorio(LojaContexto lojaContexto) : base(lojaContexto)
        {
        }

        public List<Produto> ObterTodos(string pesquisa)
        {
            // SELECT * FROM produtos WHERE nome LIKE '%%'
            return _dbSet
                .Where(x => x.Nome.Contains(pesquisa))
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
