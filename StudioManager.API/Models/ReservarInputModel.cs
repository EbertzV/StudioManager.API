using StudioManager.Application.ReservarHorario;

namespace StudioManager.API.Models
{
    public sealed class ReservarInputModel
    {
        public int IdCliente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }

    public static class ReservasInputModelExtensions
    {
        public static ReservarHorarioComando ConverterParaComando(this ReservarInputModel model, DateTime quando)
        {
            return new ReservarHorarioComando(model.IdCliente, model.Inicio, model.Fim, quando);
        }
    }
}
