namespace GuiaRestaurante.Dominio.Comando.PratoComando
{
    public class DeletarPratoComando

    {
        public DeletarPratoComando(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get; private set; }
    }
}

