using LojaRepositorios.Database;
using LojaRepositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity>
        where TEntity : EntidadeBase
    {
        private readonly LojaContexto _lojaContexto;
        protected readonly DbSet<TEntity> _dbSet;

        protected RepositorioBase(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbSet = _lojaContexto.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public TEntity DeleteLogic(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new Exception("");

            entity.Ativo = false;
            _dbSet.Update(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public TEntity DeletePhysically(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new Exception("");

            _dbSet.Remove(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public bool Any(int id)
        {
            return _dbSet.Any(x => x.Id == id);
        }
    }
}
