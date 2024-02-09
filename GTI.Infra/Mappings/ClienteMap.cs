using GTI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTI.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.Rg)
                .IsRequired(false);

            builder.Property(x => x.DataExpedicao)
                .IsRequired(false);

            builder.Property(x => x.OrgaoExpedicao)
                .IsRequired(false);

            builder.Property(x => x.Uf)
                .IsRequired(false);

            builder.Property(x => x.DataDeNascimento)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .IsRequired();

            builder.Property(x => x.EstadoCivil)
                .IsRequired();
        }
    }
}
