namespace StudioManager.DataAccess.Agenda
{
    public struct ReservaViewModel
    {
        public ReservaViewModel(int id, ClienteViewModel cliente, TimeSpan inicio, TimeSpan fim)
        {
            Id = id;
            Cliente = cliente;
            Inicio = inicio;
            Fim = fim;
        }

        public int Id { get; }
        public ClienteViewModel Cliente { get; }
        public TimeSpan Inicio { get; }
        public TimeSpan Fim { get; }
    }
}
