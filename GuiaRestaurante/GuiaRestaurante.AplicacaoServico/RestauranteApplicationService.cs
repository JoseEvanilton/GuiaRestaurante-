using GuiaRestaurante.Dominio.Comando.RestauranteComando;
using GuiaRestaurante.Dominio.Entidade;
using GuiaRestaurante.Dominio.Repositorio;
using GuiaRestaurante.Dominio.Servico;
using GuiaRestaurante.Infra.Presistencia;
using GuiaRestaurante.SharedKernel;
using GuiaRestaurante.SharedKernel.Events;
using GuiaRestaurantes.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaRestaurante.AplicacaoServico
{
    public class RestauranteApplicationService : ApplicationServiceBase, IRestauranteServico
    {
        private IRestauranteRepositorio _repository;
        private IHandler<DomainNotification> _notification;

        public RestauranteApplicationService(IRestauranteRepositorio repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public Restaurante Create(RegistrarRestauranteComando comando)
        {
            var restaurante = new Restaurante(comando.Nome, comando.Telefone, comando.Bairro, comando.Rua, comando.Numero);
            restaurante.RegisterRestaurante();
            _repository.Create(restaurante);

            if (Commit())
            {
                return restaurante;
            }

            return null;
        }

        public Restaurante Delete(DeletarRestauranteComando command)
        {
            var restaurante = _repository.GetOne(command.Nome);
            _repository.Delete(restaurante);

            if (Commit())
            {
                return restaurante;
            }

            return null;
        }

        public List<Restaurante> GetAll()
        {
            return _repository.GetAll();
        }


        public Restaurante GetOne(string nome)
        {
            return _repository.GetOne(nome);
        }

        public Restaurante GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Restaurante Update(AtualizarRestauranteComando command)
        {
            var restaurante = _repository.GetId(command.RestauranteId);
            restaurante.UpdateRestaurante(command.Nome, command.Telefone, command.Bairro, command.Rua, command.Numero);
            _repository.Update(restaurante);

            if (Commit())
            {
                return restaurante;
            }

            return null;
        }
    }
}
