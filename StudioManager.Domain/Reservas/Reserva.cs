using StudioManager.Crosscutting;
using StudioManager.Domain.Reservas.Clientes;

namespace StudioManager.Domain.Reservas
{
    public sealed class Reserva
    {
        public Reserva(int id, Cliente cliente, Horario horario, DateTime criadaEm, DateTime? canceladaEm = null)
        {
            Id = id;
            Cliente = cliente;
            Horario = horario;
            Ativa = true;
            CriadaEm = criadaEm;
            CanceladaEm = canceladaEm;
        }

        public int Id { get; private set; }
        public Cliente Cliente { get; }
        public Horario Horario { get; }
        public bool Ativa { get; private set; }
        public DateTime CriadaEm { get; }
        public DateTime? CanceladaEm { get; private set; }

        public static Reserva Nova(Cliente cliente, Horario horario, DateTime criadaEm)
            => new Reserva(0, cliente, horario, criadaEm, null);

        public void AtualizarIdentidade(int id)
            => Id = id;

        public Resultado<bool> CancelarPara(int idCliente, DateTime quando)
        {
            if (Cliente.Id != idCliente)
                return Falha.Nova(400, "A reserva não foi feita pelo cliente informado.");
            Ativa = false;
            CanceladaEm = quando;
            return true;
        }
    }
}
