using StudioManager.Crosscutting;

namespace StudioManager.Domain.Reservas.Clientes
{
    public interface IClientesRepositorio
    {
        Task<Resultado<Cliente>> RecuperarPorId(int id);
    }
}
