namespace StudioManager.DataAccess.Agenda
{
    public struct ReservaViewModel
    {
        public ReservaViewModel(int id, ClienteViewModel cliente, TimeSpan horario)
        {
            Id = id;
            Cliente = cliente;
            Horario = horario;
        }

        public int Id { get; }
        public ClienteViewModel Cliente { get; }
        public TimeSpan Horario { get; }    
    }
}
