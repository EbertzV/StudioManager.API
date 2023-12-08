namespace StudioManager.Domain.Reservas
{
    public struct Horario
    {
        private readonly int menorHorarioEmMinutos = 10;
        public Horario(DateTime inicio, DateTime fim)
        {
            Inicio = inicio;
            Fim = fim;
            if (fim <= inicio.AddMinutes(menorHorarioEmMinutos))
                throw new ArgumentOutOfRangeException("Fim", "A duração não pode ser menor que 10 minutos.");
        }

        public DateTime Inicio { get; }
        public DateTime Fim { get; }

        public bool EhIgualA(Horario other)
        {
            if (other.Inicio.Equals(Inicio) && other.Fim.Equals(Fim))
                return true;
            else
                return false;
        }

        public bool EstouEmConflitoCom(Horario horario)
        {
            if (horario.Inicio <= Inicio && horario.Fim > Inicio)
                return true;
            else if (horario.Inicio < Fim && horario.Fim >= Fim)
                return true;
            else if (horario.Inicio >= Inicio && horario.Fim <= Fim)
                return true;
            else
                return false;
        }
    }
}