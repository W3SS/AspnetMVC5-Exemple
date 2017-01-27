using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class CotacaoConfig : EntityTypeConfiguration<Cotacao>
    {
        public CotacaoConfig()
        {
            HasKey(c => c.CotacaoId);

            Property(c => c.DataCalculo)
                .IsRequired();

            Property(c => c.DataVigenciaInicial)
                .IsRequired();

            Property(c => c.DataVigenciaFinal)
                .IsRequired();

            Property(c => c.PremioTotal)
                .IsRequired();

            Property(c => c.UserId)
                 .IsRequired();

            HasRequired(c => c.TipoCalculo)
                .WithMany(t => t.Cotacoes)
                .HasForeignKey(c => c.TipoCalculoId);

            HasRequired(c => c.TipoSeguro)
               .WithMany(t => t.Cotacoes)
               .HasForeignKey(c => c.TipoSeguroId);

            Ignore(c => c.ValidationResult);

            ToTable("cotacao");
        }
    }
}
