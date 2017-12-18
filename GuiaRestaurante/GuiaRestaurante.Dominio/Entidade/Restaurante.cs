using GuiaRestaurante.Dominio.Escopos;
using System.Collections.Generic;

namespace GuiaRestaurante.Dominio.Entidade
{
    public class Restaurante
    {
        public Restaurante()
        {

        }
        public Restaurante(string nome,string telefone, string bairro, string rua, int numero)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;

            this.Prato = new List<Prato>();
        }

        public int RestauranteId { get; set; }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }

        public virtual ICollection<Prato> Prato { get; set; }

        public void RegisterRestaurante() => this.CreateRestauranteScopIsValid();
        public void UpdateRestaurante(string nome, string telefone, string bairro, string rua, int numero)
        {
            if (!this.UpdateRestauranteScopIsValid(nome,telefone, bairro, rua, numero))
                return;

            this.Nome = nome;
            this.Telefone = telefone;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
        }
    }
}
