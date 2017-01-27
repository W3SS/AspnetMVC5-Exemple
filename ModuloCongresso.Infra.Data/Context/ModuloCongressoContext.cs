using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Infra.Data.EntityConfig;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ModuloCongresso.Infra.Data.Context
{
    public class ModuloCongressoContext : DbContext
    {
        static ModuloCongressoContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public ModuloCongressoContext()
            :base("ModuloCongressoConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PaisResidencia> Paises { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Questionario> Questionarios { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<TipoSeguro> TiposSeguro { get; set; }
        public DbSet<TipoCalculo> TiposCalculo { get; set; }
        public DbSet<Rastreador> Rastreadores { get; set; }
        public DbSet<AntiFurto> AntiFurtos { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<TipoResidencia> TipoResidencia { get; set; }
        public DbSet<CoberturasItem> CoberturasItem { get; set; }
        public DbSet<Coberturas> Coberturas { get; set; }
        public DbSet<CoberturasProduto> CoberturasProdutos { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TempoHabilitacao> TempoHabilitacoes { get; set; }
        public DbSet<DistanciaTrabalho> DistanciaTrabalhos { get; set; }
        public DbSet<Uso> Usos { get; set; }
        public DbSet<Imposto> Impostos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<String>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Entity<Cotacao>()
                .Property(c => c.CotacaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            #region Entity N:N relacionamentos

            //modelBuilder.Entity<Cliente>()
            //    .HasMany<Palestra>(c => c.Palestras)
            //    .WithMany(p => p.Clientes)
            //    .Map(cp =>
            //        {
            //            cp.MapLeftKey("ClienteId");
            //            cp.MapRightKey("PalestraId");
            //            cp.ToTable("ClientePalestra");
            //        }
            //    );
            #endregion

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProfissaoConfig());
            //modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new PaisResidenciaConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new ModeloConfig());
            modelBuilder.Configurations.Add(new MarcaConfig());
            modelBuilder.Configurations.Add(new QuestionarioConfig());
            modelBuilder.Configurations.Add(new ItemConfig());
            modelBuilder.Configurations.Add(new CotacaoConfig());
            modelBuilder.Configurations.Add(new TipoCalculoConfig());
            modelBuilder.Configurations.Add(new TipoSeguroConfig());
            modelBuilder.Configurations.Add(new RastreadorConfig());
            modelBuilder.Configurations.Add(new AntiFurtoConfig());
            modelBuilder.Configurations.Add(new PerfilConfig());
            modelBuilder.Configurations.Add(new EstadoCivilConfig());
            modelBuilder.Configurations.Add(new TipoResidenciaConfig());
            modelBuilder.Configurations.Add(new CoberturasItemConfig());
            modelBuilder.Configurations.Add(new CoberturasConfig());
            modelBuilder.Configurations.Add(new CoberturasProdutoConfig());
            modelBuilder.Configurations.Add(new SexoConfig());
            modelBuilder.Configurations.Add(new TempoHabilitacaoConfig());
            modelBuilder.Configurations.Add(new DistanciaTrabalhoConfig());
            modelBuilder.Configurations.Add(new UsoConfig());
            modelBuilder.Configurations.Add(new ImpostoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = true;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCalculo") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCalculo").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCalculo").IsModified = true;
            }

            return base.SaveChanges();
        }
    }
}
