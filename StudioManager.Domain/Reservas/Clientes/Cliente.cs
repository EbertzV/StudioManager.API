namespace StudioManager.Domain.Reservas.Clientes
{
    public class Cliente
    {
        public Cliente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; }
        public string Nome { get; }
    }
}
