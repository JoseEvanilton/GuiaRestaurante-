using GuiaRestaurante.Dominio.Entidade;
using System;
using System.Linq.Expressions;

namespace GuiaRestaurante.Dominio.Especificacoes
{
    public static class PratoEspecificacoes
    {
        public static Expression<Func<Prato, bool>> GetByRestaurante(string restaurante)
        {
            return x => x.Restaurante.Nome.Equals(restaurante);
        }
        public static Expression<Func<Prato, bool>> GetPrato(string restaurante, string prato)
        {
            return x => x.Restaurante.Nome.Equals(restaurante) && x.Nome.Equals(prato);
        }
        public static Expression<Func<Prato, bool>> GetOne(string prato)
        {
            return x => x.Nome.Equals(prato);
        }
        public static Expression<Func<Prato, bool>> GetId(int id)
        {
            return x => x.PratoId == id;
        }
    }
}
