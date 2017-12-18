using System.Data.Entity;
using GuiaRestaurante.Dominio.Entidade;
using GuiaRestaurante.Infra.Presistencia.Map;
using GuiaRestaurantes.Infra.Presistence.Map;

namespace GuiaRestaurante.Infra.Presistencia.DataContexts
{

    public class DataContext : DbContext
    {
        public DataContext() : base("GuiaRestourante")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Restaurante> Restaurante { get; set; }
        public virtual DbSet<Prato> Prato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new RestauranteMap());
            modelBuilder.Configurations.Add(new PratoMap());

            base.OnModelCreating(modelBuilder);
        }
    }

}
