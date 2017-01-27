using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class MarcaConfig : EntityTypeConfiguration<Marca>
    {
        public MarcaConfig()
        {
            HasKey(m => m.MarcaId);

            Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(40);

            Property(m => m.Imagem)
                .IsOptional();

            ToTable("marca");
        }
    }
}
