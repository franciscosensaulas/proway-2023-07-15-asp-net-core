using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity: EntidadeBase
    {
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity DeleteLogic(int id);
        TEntity DeletePhysically(int id);
        bool Any(int id);
    }
}