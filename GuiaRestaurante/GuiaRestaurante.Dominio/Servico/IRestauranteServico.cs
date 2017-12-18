using GuiaRestaurante.Dominio.Comando.RestauranteComando;
using GuiaRestaurante.Dominio.Entidade;
using System.Collections.Generic;

namespace GuiaRestaurante.Dominio.Servico
{
    public interface IRestauranteServico
    {
        List<Restaurante> GetAll();
        Restaurante GetOne(string nome);
        Restaurante GetId(int id);
        Restaurante Create(RegistrarRestauranteComando command);
        Restaurante Update(AtualizarRestauranteComando command);
        Restaurante Delete(DeletarRestauranteComando command);
    }
}
