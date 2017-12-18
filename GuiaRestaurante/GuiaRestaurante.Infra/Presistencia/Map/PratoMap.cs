using GuiaRestaurante.Dominio.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace GuiaRestaurantes.Infra.Presistence.Map
{
    public class PratoMap : EntityTypeConfiguration<Prato>
    {
        public PratoMap()
        {
            ToTable("Pratos");

            HasKey(x => x.PratoId);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Preco).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            HasRequired(x => x.Restaurante);
        }
    }
}
