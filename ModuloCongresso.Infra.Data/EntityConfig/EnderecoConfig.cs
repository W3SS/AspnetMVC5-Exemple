using ModuloCongresso.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModuloCongresso.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoID);

            Property(e => e.Bairro)
                .IsRequired();

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8);

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Complemento)
                .IsOptional()
                .HasMaxLength(150);

            Property(e => e.Estado)
                .IsRequired();

            Property(e => e.Logradouro)
                .IsRequired();

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(5);

            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteID);                
                
            ToTable("enderecos");
        }
    }
}
