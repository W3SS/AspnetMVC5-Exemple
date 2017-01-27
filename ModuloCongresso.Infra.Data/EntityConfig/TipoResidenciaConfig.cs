using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class TipoResidenciaConfig : EntityTypeConfiguration<TipoResidencia>
    {
        public TipoResidenciaConfig()
        {
            HasKey(t => t.TipoResidenciaId);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            ToTable("tiporesidencia");
        }
    }
}