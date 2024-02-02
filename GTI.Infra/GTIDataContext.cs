using GTI.Domain.Entities;
using GTI.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GTI.Infra
{
    public class GTIDataContext : DbContext
    {
        public GTIDataContext(DbContextOptions<GTIDataContext> options) : base(options) { }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }
    }
}
