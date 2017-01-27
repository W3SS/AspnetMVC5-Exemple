using AutoMapper;
using ModuloCongresso.Application.ViewModels;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();
            CreateMap<ProfissaoViewModel, Profissao>();
            CreateMap<ClienteEnderecoViewModel, Profissao>();
            CreateMap<PaisResidenciaViewModel, PaisResidencia>();
            CreateMap<ClienteEnderecoViewModel, PaisResidencia>();
            CreateMap<MarcaViewModel, Marca>();
            CreateMap<ModeloViewModel, Modelo>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<QuestionarioViewModel, Questionario>();
            CreateMap<ItemViewModel, Item>();
            CreateMap<TipoSeguroViewModel, TipoSeguro>();
            CreateMap<TipoCalculoViewModel, TipoCalculo>();
            CreateMap<RastreadorViewModel, Rastreador>();
            CreateMap<AntiFurtoViewModel, AntiFurto>();
            CreateMap<PerfilViewModel, Perfil>();
            CreateMap<EstadoCivilViewModel, EstadoCivil>();
            CreateMap<TipoResidenciaViewModel, TipoResidencia>();
            CreateMap<CoberturasViewModel, Coberturas>();
            CreateMap<CotacaoViewModel, Cotacao>();
            CreateMap<CotacaoViewModel, Item>();
            CreateMap<CotacaoViewModel, Perfil>();
            CreateMap<CotacaoViewModel, Questionario>();
            CreateMap<ItemViewModel, CoberturasItem>();
            CreateMap<CotacaoViewModel, ClienteEnderecoViewModel>();
            CreateMap<SexoViewModel, Sexo>();
            CreateMap<TempoHabilitacaoViewModel, TempoHabilitacao>();
            CreateMap<DistanciaTrabalhoViewModel, DistanciaTrabalho>();
            CreateMap<UsoViewModel, Uso>();
            CreateMap<ImpostoViewModel, Imposto>();
        }
    }
}
