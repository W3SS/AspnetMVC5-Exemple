using ModuloCongresso.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteID);

            Property(c => c.Nome)
                .IsRequired();

            Property(c => c.RG)
                .IsRequired();

            Property(c => c.SobreNome)
                .IsRequired();

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index",  new IndexAnnotation(
                    new IndexAttribute() { IsUnique = false}));

            Property(c => c.email)
                .IsRequired();

            Property(c => c.telefone)
                .IsRequired();

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.ImagePhoto)
                .IsOptional();

            HasRequired(c => c.PaisResidencia)
                .WithMany(pr => pr.Clientes)
                .HasForeignKey(c => c.PaisResidenciaID);

            HasRequired(c => c.Profissao)
               .WithMany(p => p.Clientes)
               .HasForeignKey(c => c.ProfissaoID);

            HasRequired(c => c.Cotacao)
                .WithMany(cl => cl.Clientes)
                .HasForeignKey(c => c.CotacaoId);

            Ignore(c => c.ValidationResult);

            ToTable("clientes");

        }
    }
}
