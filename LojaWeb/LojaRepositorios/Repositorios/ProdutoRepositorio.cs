using LojaRepositorios.Database;
using LojaRepositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaRepositorios.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly LojaContexto _lojaContexto;
        private readonly DbSet<Produto> _dbSet;

        // Construtor: é executado quando ocorre um new da classe, ou seja,
        // new ProdutoRepositorio() irá executar o contrutor
        public ProdutoRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbSet = _lojaContexto.Set<Produto>();
        }

        public void Cadastrar(Produto produto)
        {
            _dbSet.Add(produto);
            _lojaContexto.SaveChanges();
        }

        public void Editar(Produto produto)
        {
            _dbSet.Update(produto);
            _lojaContexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var produto = _dbSet.FirstOrDefault(x => x.Id == id);

            if(produto == null) {
                throw new Exception($"Produto com código {id} não existe");
            }

            _dbSet.Remove(produto);
            _lojaContexto.SaveChanges();

        }

        public List<Produto> ObterTodos(string pesquisa)
        {
            // SELECT * FROM produtos WHERE nome LIKE '%%'
            return _dbSet
                .Where(x => x.Nome.Contains(pesquisa))
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public Produto? ObterPorId(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
