using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        List<Cliente> ObterTodos(string? pesquisa);
        Cliente? ObterPorCpf(string cpf);
    }
}
