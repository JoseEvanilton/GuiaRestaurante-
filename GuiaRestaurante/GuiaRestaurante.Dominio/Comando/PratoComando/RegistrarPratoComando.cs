namespace GuiaRestaurante.Dominio.Comando.PratoComando
{
    public class RegistrarPratoComando
    {
        public RegistrarPratoComando(string nome, string preco, int restauranteId)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.RestauranteId = restauranteId;
        }

        public string Nome { get; private set; }
        public string Preco { get; private set; }
        public int RestauranteId { get; set; }
    }
}

