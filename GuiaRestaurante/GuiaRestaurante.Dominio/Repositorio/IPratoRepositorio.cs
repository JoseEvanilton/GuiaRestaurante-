using GuiaRestaurante.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaRestaurante.Dominio.Repositorio
{
    public interface IPratoRepositorio
    {
        List<Prato> GetAll(string restaurante);
        Prato GetPrato(string restaurante, string nome);
        Prato GetOne(string nome);
        Prato GetId(int id);
        void Create(Prato prato);
        void Update(Prato prato);
        void Delete(Prato prato);
    }
}
