using LojaRepositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos
{
    internal class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("nome");

            builder.Property(x => x.Quantidade)
                .HasColumnName("quantidade");

            builder.Property(x => x.PrecoUnitario)
                .HasColumnName("preco_unitario");
        }
    }
}
