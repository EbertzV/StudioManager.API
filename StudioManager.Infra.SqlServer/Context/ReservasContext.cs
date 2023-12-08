using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace StudioManager.Infra.SqlServer.Context
{
    public class ReservasContext : DbContext
    {
        public DbSet<ReservaDB> Reservas { get; set; }
        public DbSet<ClienteDB> Clientes { get; set; }
        public string ConnectionString { get; }

        public ReservasContext()
        {
            ConnectionString = "Data Source=localhost;Initial Catalog=StudioManager;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("reservas");

            modelBuilder.Entity<ReservaDB>()
                .HasKey(r => r.Id);  
            modelBuilder.Entity<ReservaDB>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas);
            modelBuilder.Entity<ReservaDB>()
                .Property(r => r.Inicio)
                .HasColumnName("Inicio");
            modelBuilder.Entity<ReservaDB>()
                .Property(r => r.Fim)
                .HasColumnName("Fim");
        }
    }

    public class ReservaDB
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public ClienteDB Cliente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool Ativa { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime? CanceladaEm { get; set; }
    }

    public class ClienteDB
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ReservaDB> Reservas { get; set; }
    }
}
