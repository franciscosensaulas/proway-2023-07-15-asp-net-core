using LojaRepositorios.Database;
using LojaRepositorios.Entidades;
using LojaRepositorios.ExtensionMethods;

namespace LojaRepositorios.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(LojaContexto lojaContexto) : base(lojaContexto)
        {
        }

        public Cliente? ObterPorCpf(string cpf) => 
            _dbSet.FirstOrDefault(x => x.Cpf == cpf);

        public List<Cliente> ObterTodos(string? pesquisa)
        {
            var query = _dbSet.AsQueryable();

            if (pesquisa != null && pesquisa.Trim() != "")
            {
                query = query.Where(
                    x => x.Nome.Contains(pesquisa) || 
                        x.Cpf.Replace("-", "").Replace(".", "") == pesquisa.ObterCpfLimpo());
            }

            return query
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
