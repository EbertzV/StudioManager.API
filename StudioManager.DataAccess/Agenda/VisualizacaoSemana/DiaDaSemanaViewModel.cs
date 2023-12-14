namespace StudioManager.DataAccess.Agenda.VisualizacaoSemana
{
    public struct DiaDaSemanaViewModel
    {
        public DiaDaSemanaViewModel(
            DateTime dia, 
            HorarioViewModel[] reservas)
        {
            Dia = dia;
            DiaDaSemana = dia.DayOfWeek;
            Reservas = reservas;
        }

        public DateTime Dia { get; }
        public DayOfWeek DiaDaSemana { get; }
        public HorarioViewModel[] Reservas { get; }
    }
}
