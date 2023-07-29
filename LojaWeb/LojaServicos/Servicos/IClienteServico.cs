using LojaRepositorios.Entidades;

namespace LojaServicos.Servicos
{
    public interface IClienteServico
    {
        void Cadastrar(Cliente cliente);
        List<Cliente> ObterTodos(string? pesquisa);
    }
}
