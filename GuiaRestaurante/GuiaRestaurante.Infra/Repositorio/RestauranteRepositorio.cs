using GuiaRestaurante.Dominio.Entidade;
using GuiaRestaurante.Dominio.Especificacoes;
using GuiaRestaurante.Dominio.Repositorio;
using GuiaRestaurante.Infra.Presistencia.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GuiaRestaurante.Infra.Repositorio
{
    public class RestauranteRepositorio : IRestauranteRepositorio
    {
        private DataContext _context;

        public RestauranteRepositorio(DataContext context)
        {
            this._context = context;
        }

        public void Create(Restaurante restaurante)
        {
            _context.Restaurante.Add(restaurante);
        }

        public void Delete(Restaurante restaurante)
        {
            _context.Restaurante.Remove(restaurante);
        }

        public List<Restaurante> GetAll()
        {
            return _context.Restaurante.ToList();
        }


        public Restaurante GetOne(string nome)
        {
            return _context.Restaurante.Where(RestauranteEspecificacoes.GetOne(nome)).FirstOrDefault();
        }

        public Restaurante GetId(int id)
        {
            return _context.Restaurante.Where(RestauranteEspecificacoes.GetId(id)).FirstOrDefault();
        }

        public void Update(Restaurante restaurante)
        {
            _context.Entry<Restaurante>(restaurante).State = EntityState.Modified;
        }
    }
}
