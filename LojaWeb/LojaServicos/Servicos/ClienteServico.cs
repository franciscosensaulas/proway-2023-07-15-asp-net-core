using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;

namespace LojaServicos.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio _clienteRepositorio)
        {
            _repositorio = _clienteRepositorio;
        }

        public void Cadastrar(Cliente cliente)
        {
            _repositorio.Cadastrar(cliente);
        }

        public List<Cliente> ObterTodos(string? pesquisa)
        {
            var clientes = _repositorio.ObterTodos(pesquisa);
            return clientes;
        }
    }
}
