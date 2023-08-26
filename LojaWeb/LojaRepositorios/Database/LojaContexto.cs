using LojaRepositorios.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.Database
{
    public class LojaContexto : DbContext
    {
        public LojaContexto(DbContextOptions options): base(options)
        {
            /*
             * -- Instalar o dotnet ef CLI (para poder fazer migrations e atualizar o bando
             * dotnet tool install --global dotnet-ef --version 6.0.20
             * 
             * -- Apagar a versão do dotnet ef CLI
             * dotnet tool uninstall --global dotnet-ef
             * 
             * -- Buscar ferramentas com o nome dotnet-ef
             * dotnet tool search dotnet-ef
             * 
             * -- Buscar detalhamento da ferramenta dotnet-ef
             * dotnet tool search dotnet-ef --detail
             * 
             * -- Criar migration
             * dotnet ef migrations add <NomeMigration> --project LojaRepositorios --startup-project LojaAPI
             * 
             * -- Remover última migration
             * dotnet ef migrations remove --project LojaRepositorios --startup-project LojaAPI
             */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}
