using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class DistanciaTrabalhoConfig : EntityTypeConfiguration<DistanciaTrabalho>
    {
        public DistanciaTrabalhoConfig()
        {
            HasKey(d => d.DistanciaTrabalhoId);

            Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            ToTable("distanciatrabalho");
        }
    }
}