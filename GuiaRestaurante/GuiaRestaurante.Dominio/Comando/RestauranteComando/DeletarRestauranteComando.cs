namespace GuiaRestaurante.Dominio.Comando.RestauranteComando
{
    public class DeletarRestauranteComando
    {
        public DeletarRestauranteComando(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get; private set; }
    }
}
