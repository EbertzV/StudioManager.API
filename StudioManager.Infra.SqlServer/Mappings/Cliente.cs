using StudioManager.Domain.Reservas.Clientes;
using StudioManager.Infra.SqlServer.Context;

namespace StudioManager.Infra.SqlServer.Mappings
{
    public static class ClienteDBMapper
    {
        public static Cliente Map(this ClienteDB db)
        {
            return new Cliente(db.Id, db.Nome);
        }

        public static ClienteDB Map(this Cliente cliente)
        {
            return new ClienteDB()
            {
                Id = cliente.Id,
                Nome = cliente.Nome
            };
        }
    }
}
