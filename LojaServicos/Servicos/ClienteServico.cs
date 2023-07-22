using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;

namespace WindowsFormsExemplos.Servicos
{
    public class ClienteServico
    {
        private readonly ClienteRepositorio _repositorio;

        public ClienteServico()
        {
            _repositorio = new ClienteRepositorio();
        }

        public void Cadastrar(Cliente cliente)
        {
            _repositorio.Cadastrar(cliente);
        }

        public List<Cliente> ObterTodos()
        {
            var clientes = _repositorio.ObterTodos();
            return clientes;
        }
    }
}
