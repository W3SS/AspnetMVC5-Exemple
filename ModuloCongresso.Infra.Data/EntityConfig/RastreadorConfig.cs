using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class RastreadorConfig : EntityTypeConfiguration<Rastreador>
    {
        public RastreadorConfig()
        {
            HasKey(r => r.RastreadorId);

            Property(r => r.Nome)
                .IsRequired()
                .HasMaxLength(100);

            ToTable("rastreador");
        }
    }
}