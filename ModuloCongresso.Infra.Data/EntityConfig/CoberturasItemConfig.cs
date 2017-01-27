using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class CoberturasItemConfig : EntityTypeConfiguration<CoberturasItem>
    {
        public CoberturasItemConfig()
        {
            HasKey(c => c.CoberturasItemId);

            Property(c => c.Valor)
                .IsRequired();

            HasRequired(c => c.Item)
                .WithMany(i => i.Coberturas)
                .HasForeignKey(c => c.ItemId);

            HasRequired(c => c.Coberturas)
                .WithMany(i => i.CoberturasItems)
                .HasForeignKey(c => c.CoberturaId);

            ToTable("itemcoberturas");
        }
    }
}