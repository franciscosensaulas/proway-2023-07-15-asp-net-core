using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        List<Produto> ObterTodos(string pesquisa);
    }
}
