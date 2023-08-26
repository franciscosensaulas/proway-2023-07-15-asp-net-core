using LojaRepositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos
{
    internal class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        private int id = 0;

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(x => x.PrecoUnitario)
                .HasColumnType("DECIMAL")
                .HasPrecision(14, 2)
                .IsRequired()
                .HasColumnName("PrecoUnitario");

            builder.HasData(
                ConstruirProduto("TV QLED Samsung 4k 50", 5949.72m),
                ConstruirProduto("TV OLED LG 4k 50", 5300.10m));
        }

        public Produto ConstruirProduto(string nome, decimal precoUnitario) =>
            new Produto
            {
                Id = ++id,
                Nome = nome,
                PrecoUnitario = precoUnitario
            };
    }
}
