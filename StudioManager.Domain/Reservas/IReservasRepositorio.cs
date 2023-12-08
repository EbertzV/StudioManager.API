using StudioManager.Crosscutting;

namespace StudioManager.Domain.Reservas
{
    public interface IReservasRepositorio
    {
        Task<Resultado<Reserva>> RecuperarPorId(int id);
        Task<IEnumerable<Reserva>> RecuperarReservasDoDia(DateTime dia);
        void SalvarReserva(Reserva reserva, DateTime quando);
        Task<Resultado<bool>> AtualizarReserva(Reserva reserva);
    }
}
