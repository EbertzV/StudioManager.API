namespace StudioManager.DataAccess.Agenda.VisualizacaoSemana
{
    public struct DiaDaSemanaViewModel
    {
        public DiaDaSemanaViewModel(
            DayOfWeek diaDaSemana, 
            int ordem,
            ReservaViewModel[] reservas)
        {
            DiaDaSemana = diaDaSemana;
            Ordem = ordem;
            Reservas = reservas;
        }

        public DayOfWeek DiaDaSemana { get; }
        public int Ordem { get; }
        public ReservaViewModel[] Reservas { get; }
    }
}
