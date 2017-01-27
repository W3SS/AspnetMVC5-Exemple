using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class PaisResidenciaConfig : EntityTypeConfiguration<PaisResidencia>
    {
        public PaisResidenciaConfig()
        {
            HasKey(pr => pr.PaisResidenciaID);

            Property(pr => pr.Nome)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("paisresidencia");
        }
    }
}
