using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class AntiFurtoConfig : EntityTypeConfiguration<AntiFurto>
    {
        public AntiFurtoConfig()
        {
            HasKey(a => a.AntiFurtoId);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(100);

            ToTable("antifurto");
        }
    }
}