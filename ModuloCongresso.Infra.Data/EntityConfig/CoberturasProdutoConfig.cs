using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class CoberturasProdutoConfig : EntityTypeConfiguration<CoberturasProduto>
    {
        public CoberturasProdutoConfig()
        {
            HasKey(cp => cp.CoberturaProdutoId);

            Property(cp => cp.FlagObrigatorio)
                .IsRequired();

            Property(cp => cp.FlagBasica)
                .IsRequired();

            Property(cp => cp.ValorMinimo)
                .IsRequired();

            Property(cp => cp.ValorMaximo)
                .IsOptional();

            Property(cp => cp.Franquia)
                .IsRequired();

            Property(cp => cp.Taxa)
                 .IsRequired();

            HasRequired(cp => cp.Coberturas)
                .WithMany(c => c.CoberturasProduto)
                .HasForeignKey(cp => cp.CoberturaId);

            HasRequired(cp => cp.Produtos)
                .WithMany(p => p.CoberturasProduto)
                .HasForeignKey(cp => cp.ProdutoId);

            ToTable("coberturasproduto");
        }
    }
}