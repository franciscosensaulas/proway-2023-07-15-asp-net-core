using LojaRepositorios.Entidades;

namespace LojaServicos.Servicos
{
    public interface IProdutoServico
    {
        void Apagar(int id);
        void Cadastrar(Produto produto);
        void Editar(Produto produto);
        Produto? ObterPorId(int id);
        List<Produto> ObterTodos(string pesquisa);
    }
}