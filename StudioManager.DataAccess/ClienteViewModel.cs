namespace StudioManager.DataAccess
{
    public struct ClienteViewModel
    {
        public ClienteViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; }
        public string Nome { get; }
    }
}
