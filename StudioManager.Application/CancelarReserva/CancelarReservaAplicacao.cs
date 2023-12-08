using StudioManager.Crosscutting;
using StudioManager.Domain.Reservas;
using StudioManager.Domain.Reservas.Clientes;

namespace StudioManager.Application.CancelarReserva
{
    public interface ICancelarReservaAplicacao
    {
        Task<Resultado<bool>> Executar(int idReserva, int idCliente, DateTime quando);
    }

    public sealed class CancelarReservaAplicacao : ICancelarReservaAplicacao
    {
        private readonly IReservasRepositorio _reservasRepositorio;
        private readonly IClientesRepositorio _clientesRepositorio;

        public CancelarReservaAplicacao(IReservasRepositorio reservasRepositorio, IClientesRepositorio clientesRepositorio)
        {
            _reservasRepositorio = reservasRepositorio;
            _clientesRepositorio = clientesRepositorio;
        }

        public async Task<Resultado<bool>> Executar(int idReserva, int idCliente, DateTime quando)
        {
            if (await _reservasRepositorio.RecuperarPorId(idReserva) is var reserva && reserva.EhFalha)
                return reserva.Falha;
            if (reserva.Sucesso.CancelarPara(idCliente, quando) is var resultadoCancelamento && resultadoCancelamento.EhFalha)
                return resultadoCancelamento.Falha;
            if (await _reservasRepositorio.AtualizarReserva(reserva.Sucesso) is var resultadoAtualizacao && resultadoAtualizacao.EhFalha)
                return resultadoAtualizacao.Falha;
            return true;
        }
    }
}
