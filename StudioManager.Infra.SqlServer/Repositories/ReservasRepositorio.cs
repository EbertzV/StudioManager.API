using Microsoft.EntityFrameworkCore;
using StudioManager.Crosscutting;
using StudioManager.Domain.Reservas;
using StudioManager.Infra.SqlServer.Context;
using StudioManager.Infra.SqlServer.Mappings;

namespace StudioManager.Infra.SqlServer.Repositories
{
    public class ReservasRepositorio : IReservasRepositorio 
    {
        private DbSet<ReservaDB> _reservaDBs;
        private ReservasContext _dbContext;

        public async Task<Resultado<Reserva>> RecuperarPorId(int id)
        {
            _dbContext = new ReservasContext();
            _reservaDBs = _dbContext.Set<ReservaDB>();
            var reserva = await _reservaDBs.Include(r => r.Cliente).FirstOrDefaultAsync(r => r.Id == id);
            await _dbContext.DisposeAsync();
            if (reserva == null)
                return Falha.Nova(400, $"Reserva de id {id} não foi localizada.");
            return reserva.Map();
        }

        public async Task<IEnumerable<Reserva>> RecuperarReservasDoDia(DateTime dia)
        {
            _dbContext = new ReservasContext();
            _reservaDBs = _dbContext.Set<ReservaDB>();
            var reservas = _reservaDBs.Include(r => r.Cliente).Where(r => r.Inicio > dia.Date).Select(r => r.Map()).ToList();
            await _dbContext.DisposeAsync();
            return reservas;
        }

        public async Task<Resultado<bool>> AtualizarReserva(Reserva reserva)
        {
            _dbContext = new ReservasContext();
            _reservaDBs = _dbContext.Set<ReservaDB>();
            var reservaDb = _reservaDBs.Find(reserva.Id);
            if (reservaDb == null)
            {
                await _dbContext.DisposeAsync();
                return Falha.Nova(400, $"Reserva de id {reserva.Id} não encontrada.");
            }
            reservaDb.UpdateStatus(reserva);
            _dbContext.SaveChanges();
            await _dbContext.DisposeAsync();
            return true;
        }

        public void SalvarReserva(Reserva reserva, DateTime quando)
        {
            _dbContext = new ReservasContext();
            _reservaDBs = _dbContext.Set<ReservaDB>();
            var added = _reservaDBs.Add(reserva.Map());
            _dbContext.SaveChanges();
            reserva.AtualizarIdentidade(added.Entity.Id);
            _dbContext.Dispose();
        }
    }
}
