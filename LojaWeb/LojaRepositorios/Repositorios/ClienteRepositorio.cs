using LojaRepositorios.Database;
using LojaRepositorios.Entidades;
using LojaRepositorios.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaRepositorios.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LojaContexto _lojaContexto;
        private readonly DbSet<Cliente> _dbSet;

        public ClienteRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbSet = _lojaContexto.Set<Cliente>();
        }

        public void Cadastrar(Cliente cliente)
        {
            _dbSet.Add(cliente);
            _lojaContexto.SaveChanges();
        }

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
