using GuiaRestaurante.Dominio.Entidade;
using GuiaRestaurante.SharedKernel.Validation;

namespace GuiaRestaurante.Dominio.Escopos
{
    public static class RestauranteEscopos
    {
        
        
            public static bool CreateRestauranteScopIsValid(this Restaurante restaurante)
            {
                return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(restaurante.Nome, "O campo nome é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(restaurante.Telefone, "O campo telefone é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(restaurante.Bairro, "O campo bairro é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(restaurante.Rua, "O campo rua é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(restaurante.Numero.ToString(), "O campo número é Obrigatório!")
                    );
            }
            public static bool UpdateRestauranteScopIsValid(this Restaurante restaurante, string nome, string telefone, string bairro, string rua, int numero)
            {
                return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(nome, "O campo nome é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(telefone, "O campo telefone é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(bairro, "O campo bairro é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(rua, "O campo rua é Obrigatório!"),
                    AssertionConcern.AssertNotEmpty(numero.ToString(), "O campo número é Obrigatório!")
                    );
            }
        
    }
}
