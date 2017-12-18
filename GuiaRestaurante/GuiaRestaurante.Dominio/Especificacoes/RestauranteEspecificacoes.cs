using GuiaRestaurante.Dominio.Entidade;
using System;
using System.Linq.Expressions;

namespace GuiaRestaurante.Dominio.Especificacoes
{
    public static class RestauranteEspecificacoes
    {
        public static Expression<Func<Restaurante, bool>> GetOne(string nome)
        {
            return x => x.Nome.Equals(nome);
        }
        public static Expression<Func<Restaurante, bool>> GetAll()
        {
            return x => x.Nome.Equals(x.Nome);
        }
        public static Expression<Func<Restaurante, bool>> GetId(int id)
        {
            return x => x.RestauranteId == id;
        }
    }
}
