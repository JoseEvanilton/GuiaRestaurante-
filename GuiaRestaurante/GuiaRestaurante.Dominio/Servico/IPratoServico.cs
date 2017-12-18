using GuiaRestaurante.Dominio.Comando.PratoComando;
using GuiaRestaurante.Dominio.Entidade;
using System.Collections.Generic;

namespace GuiaRestaurante.Dominio.Servico
{
    public interface IPratoServico
    {
        List<Prato> GetAll(string restaurante);
        Prato GetPrato(string restaurante, string nome);
        Prato GetOne(string nome);
        Prato GetId(int id);
        Prato Create(RegistrarPratoComando comando);
        Prato Update(AtualizarPratoComando comando);
        Prato Delete(DeletarPratoComando comando);
    }
}
