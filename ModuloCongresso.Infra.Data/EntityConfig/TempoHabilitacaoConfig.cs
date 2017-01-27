using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class TempoHabilitacaoConfig : EntityTypeConfiguration<TempoHabilitacao>
    {
        public TempoHabilitacaoConfig()
        {
            HasKey(t => t.TempoHabilitacaoId);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            ToTable("tempohabilitacao");
        }
    }
}