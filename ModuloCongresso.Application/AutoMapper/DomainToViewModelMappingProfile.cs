using AutoMapper;
using ModuloCongresso.Application.ViewModels;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
            CreateMap<Profissao, ProfissaoViewModel>();
            CreateMap<Profissao, ClienteEnderecoViewModel>();
            CreateMap<PaisResidencia, PaisResidenciaViewModel>();
            CreateMap<PaisResidencia, ClienteEnderecoViewModel>();
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<Modelo, ModeloViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Questionario, QuestionarioViewModel>();
            CreateMap<Item, ItemViewModel>();
            CreateMap<TipoCalculo, TipoCalculoViewModel>();
            CreateMap<TipoSeguro, TipoSeguroViewModel>();
            CreateMap<Rastreador, RastreadorViewModel>();
            CreateMap<AntiFurto, AntiFurtoViewModel>();
            CreateMap<Perfil, PerfilViewModel>();
            CreateMap<EstadoCivil, EstadoCivilViewModel>();
            CreateMap<TipoResidencia, TipoResidenciaViewModel>();
            CreateMap<Coberturas, CoberturasViewModel>();
            CreateMap<Cotacao, CotacaoViewModel>();
            CreateMap<Item, CotacaoViewModel>();
            CreateMap<Perfil, CotacaoViewModel>();
            CreateMap<Questionario, CotacaoViewModel>();
            CreateMap<CoberturasItem, ItemViewModel>();
            CreateMap<ClienteEnderecoViewModel, CotacaoViewModel>();
            CreateMap<Sexo, SexoViewModel>();
            CreateMap<TempoHabilitacao, TempoHabilitacaoViewModel>();
            CreateMap<DistanciaTrabalho, DistanciaTrabalhoViewModel>();
            CreateMap<Uso, UsoViewModel>();
            CreateMap<Imposto, ImpostoViewModel>();
        }
    }
}
