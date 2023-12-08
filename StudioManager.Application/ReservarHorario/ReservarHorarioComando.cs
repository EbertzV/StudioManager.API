namespace StudioManager.Application.ReservarHorario
{
    public sealed class ReservarHorarioComando
    {
        public ReservarHorarioComando(int idCliente, DateTime inicio, DateTime fim, DateTime quando)
        {
            IdCliente = idCliente;
            Inicio = inicio;
            Fim = fim;
            Quando = quando;
        }

        public int IdCliente { get; }
        public DateTime Inicio { get; }
        public DateTime Fim { get; }
        public DateTime Quando { get; }
    }
}