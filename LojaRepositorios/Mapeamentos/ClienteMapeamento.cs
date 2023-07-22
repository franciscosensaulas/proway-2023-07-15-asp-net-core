using LojaRepositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos
{
    internal class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Cpf).HasColumnName("cpf");
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

            builder.Property(x => x.Endereco.Estado).HasColumnName("estado");
            builder.Property(x => x.Endereco.Cidade).HasColumnName("cidade");
            builder.Property(x => x.Endereco.Bairro).HasColumnName("bairro");
            builder.Property(x => x.Endereco.Cep).HasColumnName("cep");
            builder.Property(x => x.Endereco.Logradouro).HasColumnName("logradouro");
            builder.Property(x => x.Endereco.Numero).HasColumnName("numero");
            builder.Property(x => x.Endereco.Complemento).HasColumnName("complemento");
        }
    }
}
