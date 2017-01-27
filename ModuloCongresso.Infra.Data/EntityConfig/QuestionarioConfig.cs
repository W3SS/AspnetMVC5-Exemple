using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class QuestionarioConfig : EntityTypeConfiguration<Questionario>
    {
        public QuestionarioConfig()
        {
            HasKey(q => q.QuestionarioId);

            HasOptional(q => q.Rastreador)
                .WithMany(r => r.Questionarios)
                .HasForeignKey(q => q.RastreadorId);


            HasOptional(q => q.AntiFurto)
                .WithMany(a => a.Questionarios)
                .HasForeignKey(q => q.AntiFurtoId);

            Property(q => q.CepPernoite)
                .IsRequired()
                .HasMaxLength(8);

            Property(q => q.RelacaoSegurado)
                .IsRequired()
                .HasMaxLength(100);

            Property(q => q.FlagBlindado)
                .IsRequired();

            Property(q => q.FlagAdaptadoDeficiente)
               .IsRequired();

            Property(q => q.FlagKitGas)
               .IsRequired();

            Property(q => q.FlagAlienado)
                .IsRequired();

            Property(q => q.FlagAntiFurto)
                .IsRequired();

            Property(q => q.FlagGararem)
                .IsRequired();

            Property(q => q.GararemFaculdade)
                .IsOptional()
                .HasMaxLength(100);

            Property(q => q.GararemResidencia)
                .IsOptional()
                .HasMaxLength(100);

            Property(q => q.GararemTrabalho)
                .IsOptional()
                .HasMaxLength(100);

            Property(q => q.PropriedadeRastreador)
                .IsOptional()
                .HasMaxLength(100);

            HasRequired(q => q.Cotacao)
                .WithMany(c => c.Questionarios)
                .HasForeignKey(q => q.CotacaoId);

            ToTable("questionario");
        }
    }
}
