using GuiaRestaurante.AplicacaoServico;
using GuiaRestaurante.Dominio.Repositorio;
using GuiaRestaurante.Dominio.Servico;
using GuiaRestaurante.Infra.Presistencia;
using GuiaRestaurante.Infra.Presistencia.DataContexts;
using GuiaRestaurante.Infra.Repositorio;
using GuiaRestaurante.SharedKernel;
using GuiaRestaurantes.SharedKernel.Events;
using Unity;
using Unity.Lifetime;

namespace GuiaRestaurante.CrossCutting
{
    public static class DependencyRegister
    {
        /// <param name="conatiner"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<DataContext, DataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestauranteRepositorio, RestauranteRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IPratoRepositorio, PratoRepositorio>(new HierarchicalLifetimeManager());

            container.RegisterType<IRestauranteServico, RestauranteApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPratoServico, PratoApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

        }
    }
}
