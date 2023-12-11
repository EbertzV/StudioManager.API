namespace StudioManager.DataAccess.Agenda.VisualizacaoSemana
{
    public struct DiaDaSemanaViewModel
    {
        public DiaDaSemanaViewModel(
            DateTime dia, 
            ReservaViewModel[] reservas)
        {
            Dia = dia;
            Reservas = reservas;
        }

        public DateTime Dia { get; }
        public ReservaViewModel[] Reservas { get; }
    }
}
