namespace GuiaRestaurante.Dominio.Comando.RestauranteComando
{
    public class AtualizarRestauranteComando
    {
        public AtualizarRestauranteComando(int restauranteId, string nome, string telefone, string bairro, string rua, int numero)
        {
            this.RestauranteId = restauranteId;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
        }

        public int RestauranteId { get; set; }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
    }
}

