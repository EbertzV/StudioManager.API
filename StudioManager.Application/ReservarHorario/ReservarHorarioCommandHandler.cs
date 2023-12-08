using StudioManager.Crosscutting;
using StudioManager.Domain.Reservas;
using StudioManager.Domain.Reservas.Clientes;
using StudioManager.Domain.Reservas.Validacoes;

namespace StudioManager.Application.ReservarHorario
{
    public interface IReservarHorarioCommandHandler
    {
        Task<Resultado<Reserva>> Executar(ReservarHorarioComando comando);
    }

    public sealed class ReservarHorarioCommandHandler : IReservarHorarioCommandHandler
    {
        private readonly IReservasRepositorio _reservasRepositorio;
        private readonly IClientesRepositorio _clientesRepositorio;
        public ReservarHorarioCommandHandler(IReservasRepositorio reservasRepositorio, IClientesRepositorio clientesRepositorio)
        {
            _reservasRepositorio = reservasRepositorio;
            _clientesRepositorio = clientesRepositorio;
        }

        public async Task<Resultado<Reserva>> Executar(ReservarHorarioComando comando)
        {
            if (await _clientesRepositorio.RecuperarPorId(comando.IdCliente) is var cliente && cliente.EhFalha)
                return cliente.Falha;

            var reservasDoDia = await _reservasRepositorio.RecuperarReservasDoDia(comando.Inicio.Date);
            var novoHorario = new Horario(comando.Inicio, comando.Fim);

            var reservasComConflito = ValidadorConflitoHorario.ReservasComConflito(
                reservasDoDia.Where(r => r.Ativa),
                novoHorario);

            if (reservasComConflito.Any())
                return Falha.Nova(
                    400, "O horário selecionado conflita com uma reserva existente.",
                    reservasComConflito.Select(r => r.Id.ToString()).ToArray());

            var novaReserva = Reserva.Nova(cliente.Sucesso, novoHorario, comando.Quando);

            _reservasRepositorio.SalvarReserva(novaReserva, comando.Quando);

            return novaReserva;
        }
    }
}