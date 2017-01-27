using ModuloCongresso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class ProfissaoConfig : EntityTypeConfiguration<Profissao>
    {
        public ProfissaoConfig()
        {
            HasKey(p => p.ProfissaoID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            ToTable("profissoes");
        }
    }
}
