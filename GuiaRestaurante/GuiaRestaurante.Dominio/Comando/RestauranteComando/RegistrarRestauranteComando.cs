namespace GuiaRestaurante.Dominio.Comando.RestauranteComando
{
    public class RegistrarRestauranteComando
    {
        public RegistrarRestauranteComando(string nome,string telefone, string bairro, string rua, int numero)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;

        }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
 
    }
}
