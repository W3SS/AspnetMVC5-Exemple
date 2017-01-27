using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class TipoCalculoConfig : EntityTypeConfiguration<TipoCalculo>
    {
        public TipoCalculoConfig()
        {
            HasKey(t => t.TipoCalculoId);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("tipocalculo");
        }
    }
}