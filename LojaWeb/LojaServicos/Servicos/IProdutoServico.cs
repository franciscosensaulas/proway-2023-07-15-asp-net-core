using LojaServicos.Dtos.Produtos;

namespace LojaServicos.Servicos
{
    public interface IProdutoServico
    {
        void Apagar(int id);
        int Cadastrar(ProdutoCadastrarDto dto);
        void Editar(ProdutoEditarDto dto);
        ProdutoIndexDto? ObterPorId(int id);
        List<ProdutoIndexDto> ObterTodos(string pesquisa);
    }
}