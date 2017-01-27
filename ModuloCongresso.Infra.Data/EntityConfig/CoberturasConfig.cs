using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class CoberturasConfig : EntityTypeConfiguration<Coberturas>
    {
        public CoberturasConfig()
        {
            HasKey(c => c.CoberturaId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            Property(m => m.Imagem)
                .IsOptional();

            Property(c => c.Info)
                .IsRequired()
                .HasMaxLength(1000);

            ToTable("coberturas");
        }
    }
}