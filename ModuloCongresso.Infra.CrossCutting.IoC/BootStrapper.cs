using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ModuloCongresso.Application;
using ModuloCongresso.Application.Interfaces;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.Services;
using ModuloCongresso.Domain.Interfaces.Repository;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services;
using ModuloCongresso.Domain.Interfaces.Services.Business;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using ModuloCongresso.Domain.Services;
using ModuloCongresso.Domain.Services.Business;
using ModuloCongresso.Domain.Services.CotacaoService;
using ModuloCongresso.Infra.CrossCutting.Identity.Configuration;
using ModuloCongresso.Infra.CrossCutting.Identity.Context;
using ModuloCongresso.Infra.CrossCutting.Identity.Model;
using ModuloCongresso.Infra.Data.Context;
using ModuloCongresso.Infra.Data.Interfaces;
using ModuloCongresso.Infra.Data.Repository;
using ModuloCongresso.Infra.Data.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.UnitOfWork;
using SimpleInjector;

namespace ModuloCongresso.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //App
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IProfissaoAppService, ProfissaoAppService>(Lifestyle.Scoped);
            container.Register<IPaisResidenciaAppService, PaisResidenciaAppService>(Lifestyle.Scoped);
            container.Register<ICotacaoAppService, CotacaoAppService>(Lifestyle.Scoped);
            container.Register<IMarcaAppService, MarcaAppService>(Lifestyle.Scoped);
            container.Register<IModeloAppService, ModeloAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);
            container.Register<IQuestionarioAppService, QuestionarioAppService>(Lifestyle.Scoped);
            container.Register<IItemAppService, ItemAppService>(Lifestyle.Scoped);
            container.Register<ITipoSeguroAppService, TipoSeguroAppService>(Lifestyle.Scoped);
            container.Register<ITipoCalculoAppService, TipoCalculoAppService>(Lifestyle.Scoped);
            container.Register<IRastreadorAppService, RastreadorAppService>(Lifestyle.Scoped);
            container.Register<IAntiFurtoAppService, AntiFurtoAppService>(Lifestyle.Scoped);
            container.Register<IPerfilAppService, PerfilAppService>(Lifestyle.Scoped);
            container.Register<IEstadoCivilAppService, EstadoCivilAppService>(Lifestyle.Scoped);
            container.Register<ITipoResidenciaAppService, TipoResidenciaAppService>(Lifestyle.Scoped);
            container.Register<ICoberturaAppService, CoberturaAppService>(Lifestyle.Scoped);
            container.Register<ICoberturaItemAppService, CoberturaItemAppService>(Lifestyle.Scoped);
            container.Register<ISexoAppService, SexoAppService>(Lifestyle.Scoped);
            container.Register<ITempoHabilitacaoAppService, TempoHabilitacaoAppService>(Lifestyle.Scoped);
            container.Register<IDistanciaTrabalhoAppService, DistanciaTrabalhoAppService>(Lifestyle.Scoped);
            container.Register<IUsoAppService, UsoAppService>(Lifestyle.Scoped);
            container.Register<IImpostoAppService, ImpostoAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IProfissaoService, ProfissaoService>(Lifestyle.Scoped);
            container.Register<IPaisResidenciaService, PaisResidenciaService>(Lifestyle.Scoped);
            container.Register<ICotacaoService, CotacaoService>(Lifestyle.Scoped);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Scoped);
            container.Register<IModeloService, ModeloService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IQuestionarioService, QuestionarioService>(Lifestyle.Scoped);
            container.Register<IItemService, ItemService>(Lifestyle.Scoped);
            container.Register<ITipoSeguroService, TipoSeguroService>(Lifestyle.Scoped);
            container.Register<ITipoCalculoService, TipoCalculoService>(Lifestyle.Scoped);
            container.Register<IRastreadorService, RastreadorService>(Lifestyle.Scoped);
            container.Register<IAntiFurtoService, AntiFurtoService>(Lifestyle.Scoped);
            container.Register<IPerfilService, PerfilService>(Lifestyle.Scoped);
            container.Register<IEstadoCivilService, EstadoCivilService>(Lifestyle.Scoped);
            container.Register<ITipoResidenciaService, TipoResidenciaService>(Lifestyle.Scoped);
            container.Register<ICoberturasProdutoService, CoberturasProdutoService>(Lifestyle.Scoped);
            container.Register<ICoberturaService, CoberturaService>(Lifestyle.Scoped);
            container.Register<ICoberturaItemService, CoberturaItemService>(Lifestyle.Scoped);
            container.Register<ICalculoService, CalculoService>(Lifestyle.Scoped);
            container.Register<ISexoService, SexoService>(Lifestyle.Scoped);
            container.Register<ITempoHabilitacaoService, TempoHabilitacaoService>(Lifestyle.Scoped);
            container.Register<IDistanciaTrabalhoService, DistanciaTrabalhoService>(Lifestyle.Scoped);
            container.Register<IUsoService, UsoService>(Lifestyle.Scoped);
            container.Register<IImpostoService, ImpostoService>(Lifestyle.Scoped);
            container.Register<IEnderecoService, EnderecoService>(Lifestyle.Scoped);

            //Data 
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IProfissaoRepository, ProfissaoRepository>(Lifestyle.Scoped);
            container.Register<IPaisResidenciaRepository, PaisResidenciaRepository>(Lifestyle.Scoped);
            container.Register<ICotacaoRepository, CotacaoRepository>(Lifestyle.Scoped);
            container.Register<IMarcaRepository, MarcaRepository>(Lifestyle.Scoped);
            container.Register<IModeloRepository, ModeloRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IQuestionarioRepository, QuestionarioRepository>(Lifestyle.Scoped);
            container.Register<IItemRepository, ItemRepository>(Lifestyle.Scoped);
            container.Register<ITipoCalculoRepository, TipoCalculoRepository>(Lifestyle.Scoped);
            container.Register<ITipoSeguroRepository, TipoSeguroRepository>(Lifestyle.Scoped);
            container.Register<IRastreadorRepository, RastreadorRepository>(Lifestyle.Scoped);
            container.Register<IAntiFurtoRepository, AntiFurtoRepository>(Lifestyle.Scoped);
            container.Register<IPerfilRepository, PerfilRepository>(Lifestyle.Scoped);
            container.Register<IEstadoCivilRepository, EstadoCivilRepository>(Lifestyle.Scoped);
            container.Register<ITipoResidenciaRepository, TipoResidenciaRepository>(Lifestyle.Scoped);
            container.Register<ICoberturasProdutoRepository, CoberturasProdutoRepository>(Lifestyle.Scoped);
            container.Register<ICoberturaRepository, CoberturasRepository>(Lifestyle.Scoped);
            container.Register<ICoberturaItemRepository, CoberturaItemRepository>(Lifestyle.Scoped);
            container.Register<ISexoRepository, SexoRepository>(Lifestyle.Scoped);
            container.Register<ITempoHabilitacaoRepository, TempoHabilitacaoRepository>(Lifestyle.Scoped);
            container.Register<IDistanciaTrabalhoRepository, DistanciaTrabalhoRepository>(Lifestyle.Scoped);
            container.Register<IUsoRepository, UsoRepository>(Lifestyle.Scoped);
            container.Register<IImpostoRepository, ImpostoRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ModuloCongressoContext>(Lifestyle.Scoped);

            //Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();
        }
    }
}
