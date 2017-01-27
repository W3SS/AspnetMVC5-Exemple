using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class UsoConfig : EntityTypeConfiguration<Uso>
    {
        public UsoConfig()
        {
            HasKey(u => u.UsoId);

            Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(80);

            ToTable("Uso");
        }
    }
}