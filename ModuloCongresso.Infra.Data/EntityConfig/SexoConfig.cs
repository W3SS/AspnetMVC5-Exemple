using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class SexoConfig : EntityTypeConfiguration<Sexo>
    {
        public SexoConfig()
        {
            HasKey(s => s.SexoId);

            Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            ToTable("sexo");
        }
    }
}