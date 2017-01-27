using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class EstadoCivilConfig : EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilConfig()
        {
            HasKey(e => e.EstadoCivilId);

            Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            ToTable("estadocivil");
        }
    }
}