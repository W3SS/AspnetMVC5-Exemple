using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class TipoSeguroConfig : EntityTypeConfiguration<TipoSeguro>
    {
        public TipoSeguroConfig()
        {
            HasKey(t => t.TipoSeguroId);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("tiposeguro");
        }
    }
}