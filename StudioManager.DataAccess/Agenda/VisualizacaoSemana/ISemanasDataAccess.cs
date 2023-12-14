using StudioManager.Crosscutting;

namespace StudioManager.DataAccess.Agenda.VisualizacaoSemana
{
    public interface ISemanasDataAccess
    {
        Task<Resultado<DiaDaSemanaViewModel[]>> RecuperarReservasDaSemanaAPartirDe(DateTime quando, int diasParaFrente);
    }
}
