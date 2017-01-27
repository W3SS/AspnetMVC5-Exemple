using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class ItemConfig : EntityTypeConfiguration<Item>
    {
        public ItemConfig()
        {
            HasKey(i => i.ItemId);

            HasRequired(i => i.Imposto)
                .WithMany(im => im.Itens)
                .HasForeignKey(i => i.ImpostoId);

            HasRequired(i => i.Uso)
                .WithMany(u => u.Itens)
                .HasForeignKey(i => i.UsoId);

            HasRequired(i => i.Modelo)
                .WithMany()
                .HasForeignKey(i => i.ModeloId);

            HasRequired(i => i.Produto)
                .WithMany()
                .HasForeignKey(i => i.ProdutoId);

            HasRequired(i => i.Cotacao)
                .WithMany(c => c.Itens)
                .HasForeignKey(i => i.CotacaoId);

            Property(i => i.NumChassi)
                .IsOptional();

            Property(i => i.FlagRemarcado)
                .IsRequired();

            ToTable("item");
        }
    }
}
