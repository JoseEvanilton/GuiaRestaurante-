using GuiaRestaurante.Dominio.Comando.PratoComando;
using GuiaRestaurante.Dominio.Entidade;
using GuiaRestaurante.Dominio.Repositorio;
using GuiaRestaurante.Dominio.Servico;
using GuiaRestaurante.Infra.Presistencia;
using GuiaRestaurante.SharedKernel;
using GuiaRestaurante.SharedKernel.Events;
using GuiaRestaurantes.SharedKernel.Events;
using System.Collections.Generic;


namespace GuiaRestaurante.AplicacaoServico
{
    public class PratoApplicationService : ApplicationServiceBase, IPratoServico
    {
        private IPratoRepositorio _repository;
        private IHandler<DomainNotification> _notification;

        public PratoApplicationService(IPratoRepositorio repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public Prato Create(RegistrarPratoComando command)
        {
            var prato = new Prato(command.Nome, command.Preco, command.RestauranteId);
            prato.RegisterPrato();
            _repository.Create(prato);

            if (Commit())
            {
                return prato;
            }

            return null;
        }

        public Prato Delete(DeletarPratoComando command)
        {
            var prato = _repository.GetOne(command.Nome);
            _repository.Delete(prato);

            if (Commit())
            {
                return prato;
            }

            return null;
        }

        public List<Prato> GetAll(string restaurante)
        {
            return _repository.GetAll(restaurante);
        }

        public Prato GetPrato(string restaurante, string prato)
        {
            return _repository.GetPrato(restaurante, prato);
        }

        public Prato GetOne(string prato)
        {
            return _repository.GetOne(prato);
        }

        public Prato GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Prato Update(AtualizarPratoComando command)
        {
            var prato = _repository.GetId(command.PratoId);
            prato.UpdatePrato(command.Nome, command.Preco);
            _repository.Update(prato);

            if (Commit())
            {
                return prato;
            }

            return null;
        }
    }
}
