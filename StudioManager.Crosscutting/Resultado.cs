namespace StudioManager.Crosscutting
{
    public class Resultado<T>
    {
        private Resultado(T sucesso, Falha? falha, bool ehSucesso)
        {
            Sucesso = sucesso;
            Falha = falha;
            EhSucesso = ehSucesso;
            EhFalha = !EhSucesso;
        }

        public T Sucesso { get; }
        public Falha? Falha { get; }
        public bool EhSucesso { get; }
        public bool EhFalha { get; }

        public static Resultado<T> NovoSucesso(T sucesso)
            => new(sucesso, null, true);

        public static Resultado<T> NovaFalha(Falha falha)
            => new(default, falha, false);

        public static implicit operator Resultado<T>(T sucesso)
            => NovoSucesso(sucesso);

        public static implicit operator Resultado<T>(Falha falha)
            => NovaFalha(falha);
    }

    public class Falha
    {
        public Falha(int codigo, string mensagem, string[] detalhes)
        {
            Codigo = codigo;
            Mensagem = mensagem;
            Detalhes = detalhes;
        }

        public int Codigo { get; }
        public string Mensagem { get; }
        public string[] Detalhes { get; }

        public static Falha Nova(int codigo, string mensagem)
            => new(codigo, mensagem, Array.Empty<string>());

        public static Falha Nova(int codigo, string mensagem, string[] detalhes)
            => new(codigo, mensagem, detalhes);
    }
}
