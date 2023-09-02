using LojaRepositorios.Database;
using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios;

public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(LojaContexto lojaContexto) : base(lojaContexto)
    {
    }

    public Usuario? GetByEmailAndPassword(string email, string senha) => 
        _dbSet.FirstOrDefault(x => x.Email == email && x.Senha == senha);
}