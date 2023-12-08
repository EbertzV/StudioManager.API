using Microsoft.EntityFrameworkCore;

namespace StudioManager.Infra
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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("reservas");
        }
    }

    public class ReservaDB
    {
        public int Id { get; set; }
        public ClienteDB Cliente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public DateTime CriadaEm { get; set; }
        public bool Ativa { get; set; }
        public DateTime? CanceladaEm { get; set; }
    }

    public class ClienteDB
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
