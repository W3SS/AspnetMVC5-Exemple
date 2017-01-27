using System.Data.Entity.ModelConfiguration;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class PerfilConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfig()
        {
            HasKey(p => p.PerfilId);

            HasRequired(p => p.TipoResidencia)
                .WithMany(t => t.Perfis)
                .HasForeignKey(p => p.TipoResidenciaId);

            HasRequired(p => p.EstadoCivil)
                .WithMany(e => e.Perfis)
                .HasForeignKey(p => p.EstadoCivilId);

            Property(p => p.CpfPrincipalCondutor)
                .IsRequired()
                .HasMaxLength(11);

            Property(p => p.NomePrincipalCondutor)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.DataNascPrincipalCondutor)
                .IsRequired();

            Property(p => p.FlagResideMenorIdade)
                .IsRequired();

            Property(p => p.FlagSegPrincipalCondutor)
                .IsRequired();

            Property(p => p.FlagPontosCarteira)
                .IsRequired();

            HasRequired(p => p.Sexo)
                .WithMany(s => s.Perfis)
                .HasForeignKey(p => p.SexoId);

            HasRequired(p => p.TempoHabilitacao)
                .WithMany(t => t.Perfis)
                .HasForeignKey(p => p.TempoHabilitacaoId);

            HasRequired(p => p.DistanciaTrabalho)
                .WithMany(d => d.Perfis)
                .HasForeignKey(p => p.DistanciaResidenciaTrabalhoId);

            Property(p => p.QuantidadeVeicResidencia)
                .IsRequired();

            HasRequired(p => p.Cotacao)
                .WithMany(c => c.Perfils)
                .HasForeignKey(p => p.CotacaoId);

            ToTable("perfil");
        }
    }
}