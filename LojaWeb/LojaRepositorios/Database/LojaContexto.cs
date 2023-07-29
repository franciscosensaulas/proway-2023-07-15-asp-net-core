﻿using LojaRepositorios.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.Database
{
    public class LojaContexto : DbContext
    {
        public LojaContexto(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}
