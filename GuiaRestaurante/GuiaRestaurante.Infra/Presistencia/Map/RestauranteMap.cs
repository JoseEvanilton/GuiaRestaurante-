using GuiaRestaurante.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaRestaurante.Infra.Presistencia.Map
{
    public class RestauranteMap : EntityTypeConfiguration<Restaurante>
    {
        public RestauranteMap()
        {
            ToTable("Restaurantes");

            HasKey(x => x.RestauranteId);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Telefone).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Bairro).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Rua).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Numero).IsRequired();


            HasMany(X => X.Prato);
        }
    }
}
