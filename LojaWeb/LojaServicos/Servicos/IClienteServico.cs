using LojaServicos.Dtos.Clientes;

namespace LojaServicos.Servicos
{
    public interface IClienteServico
    {
        void Cadastrar(ClienteCadastrarDto cliente);
        List<ClienteIndexDto> ObterTodos(string? pesquisa);
    }
}
