using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class ImpostoConfig : EntityTypeConfiguration<Imposto>
    {
        public ImpostoConfig()
        {
            HasKey(i => i.ImpostoId);

            Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(80);

            ToTable("Imposto");
        }
    }
}