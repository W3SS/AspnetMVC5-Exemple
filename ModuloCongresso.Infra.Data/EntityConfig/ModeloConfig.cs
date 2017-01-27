using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class ModeloConfig : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfig()
        {
            HasKey(m => m.ModeloId);

            Property(m => m.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(m => m.AnoFabricacao)
                .IsRequired()
                .HasMaxLength(4);

            Property(m => m.AnoModelo)
                .IsRequired()
                .HasMaxLength(4);

            Property(i => i.FlagZeroKm)
                .IsRequired();

            Property(m => m.Valor)
                .IsRequired();

            HasRequired(m => m.Marca)
                .WithMany(m => m.Modelos)
                .HasForeignKey(m => m.MarcaId);

            ToTable("modelo");
        }
    }
}
