using Microsoft.EntityFrameworkCore;
using StudioManager.Crosscutting;
using StudioManager.Domain.Reservas.Clientes;
using StudioManager.Infra.SqlServer.Context;
using StudioManager.Infra.SqlServer.Mappings;

namespace StudioManager.Infra.SqlServer.Repositories
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private DbSet<ClienteDB> _clienteDBs;
        private ReservasContext _dbContext;

        public ClientesRepositorio()
        {
            
        }

        public async Task<Resultado<Cliente>> RecuperarPorId(int id)
        {
            _dbContext = new ReservasContext();
            _clienteDBs = _dbContext.Set<ClienteDB>();
            var db = await _clienteDBs.FindAsync(id);
            if (db == null)
                return Falha.Nova(400, $"Cliente {id} não localizado.");
            var result = db.Map();
            await _dbContext.DisposeAsync();
            return result;
        }
    }
}
