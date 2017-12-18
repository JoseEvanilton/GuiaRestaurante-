using GuiaRestaurante.Dominio.Entidade;
using GuiaRestaurante.Dominio.Especificacoes;
using GuiaRestaurante.Dominio.Repositorio;
using GuiaRestaurante.Infra.Presistencia.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GuiaRestaurante.Infra.Repositorio
{
    public class PratoRepositorio : IPratoRepositorio
    {
        private DataContext _context;

        public PratoRepositorio(DataContext context)
        {
            this._context = context;
        }

        public void Create(Prato prato)
        {
            _context.Prato.Add(prato);
        }

        public void Delete(Prato prato)
        {
            _context.Prato.Remove(prato);
        }

        public List<Prato> GetAll(string restaurante)
        {
            return _context.Prato.Where(PratoEspecificacoes.GetByRestaurante(restaurante)).OrderBy(x => x.Nome).ToList();
        }

        public Prato GetPrato(string restaurante, string nome)
        {
            return _context.Prato.Where(PratoEspecificacoes.GetPrato(restaurante, nome)).FirstOrDefault();
        }

        public Prato GetOne(string nome)
        {
            return _context.Prato.Where(PratoEspecificacoes.GetOne(nome)).FirstOrDefault();
        }

        public Prato GetId(int id)
        {
            return _context.Prato.Where(PratoEspecificacoes.GetId(id)).FirstOrDefault();
        }

        public void Update(Prato prato)
        {
            _context.Entry<Prato>(prato).State = EntityState.Modified;
        }
    }
}
