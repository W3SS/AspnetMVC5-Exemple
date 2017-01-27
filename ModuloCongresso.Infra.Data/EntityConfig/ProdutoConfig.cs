using ModuloCongresso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            ToTable("produto");
        }
    }
}
