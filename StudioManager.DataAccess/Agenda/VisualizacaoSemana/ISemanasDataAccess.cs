using StudioManager.Crosscutting;

namespace StudioManager.DataAccess.Agenda.VisualizacaoSemana
{
    public interface ISemanasDataAccess
    {
        Task<Resultado<SemanaViewModel>> RecuperarReservasDaSemanaAPartirDe(DateTime quando);
    }
}
