namespace StudioManager.Domain.Reservas.Validacoes
{
    public static class ValidadorConflitoHorario
    {

        public static IEnumerable<Reserva> ReservasComConflito(IEnumerable<Reserva> reservas, Horario novoHorario)
        {
            var reservasEnumerator = reservas.GetEnumerator();  
            while(reservasEnumerator.MoveNext())
            {
                if (reservasEnumerator.Current.Horario.EstouEmConflitoCom(novoHorario))
                    yield return reservasEnumerator.Current;
            }
        }
    }
}
