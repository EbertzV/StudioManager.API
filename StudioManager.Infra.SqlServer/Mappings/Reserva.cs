using StudioManager.Domain.Reservas;
using StudioManager.Infra.SqlServer.Context;

namespace StudioManager.Infra.SqlServer.Mappings
{
    public static class ReservaMap
    {
        public static Reserva Map(this ReservaDB db)
        {
            return new Reserva(db.Id, db.Cliente.Map(), new Horario(db.Inicio, db.Fim), db.CriadaEm, db.CanceladaEm);
        }

        public static ReservaDB Map(this Reserva reserva)
        {
            return new ReservaDB()
            {
                Id = reserva.Id,
                Inicio = reserva.Horario.Inicio,
                Fim = reserva.Horario.Fim,
                ClienteId = reserva.Cliente.Id,
                Ativa = reserva.Ativa,
                CriadaEm = reserva.CriadaEm,
                CanceladaEm = reserva.CanceladaEm
            };
        }

        public static ReservaDB UpdateStatus(this ReservaDB reservaDb, Reserva reserva)
        {
            reservaDb.Ativa = reserva.Ativa;
            reservaDb.CanceladaEm = reserva.CanceladaEm;
            return reservaDb;
        }
    }
}
