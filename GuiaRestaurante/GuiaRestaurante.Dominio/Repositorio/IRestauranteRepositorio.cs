using GuiaRestaurante.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaRestaurante.Dominio.Repositorio
{
    public interface IRestauranteRepositorio
    {
        List<Restaurante> GetAll();
        //List<Restaurante> GetByRestaurante(string email);
        Restaurante GetOne(string nome);
        Restaurante GetId(int id);
        void Create(Restaurante restaurante);
        void Update(Restaurante restaurante);
        void Delete(Restaurante restaurante);
    }
}
