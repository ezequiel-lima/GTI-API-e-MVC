using GTI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GTI.Infra.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cep)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Logradouro)
                .IsRequired();

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Complemento);

            builder.Property(x => x.Bairro)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .IsRequired();

            builder.Property(x => x.Uf)
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Enderecos)
                .HasConstraintName("FK_Endereco_Cliente");
        }
    }
}
