using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios;

public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
{
    Usuario? GetByEmailAndPassword(string email, string senha);
}