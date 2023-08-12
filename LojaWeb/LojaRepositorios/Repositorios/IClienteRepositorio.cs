using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public interface IClienteRepositorio
    {
        void Cadastrar(Cliente cliente);
        List<Cliente> ObterTodos(string? pesquisa);
        Cliente? ObterPorCpf(string cpf);
        bool ExisteComCpf(string cpf);
    }
}
