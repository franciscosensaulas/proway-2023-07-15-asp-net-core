using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public interface IProdutoRepositorio
    {
        void Cadastrar(Produto produto);
        void Editar(Produto produto);
        void Apagar(int id);
        List<Produto> ObterTodos(string pesquisa);
        Produto? ObterPorId(int id);
    }
}
