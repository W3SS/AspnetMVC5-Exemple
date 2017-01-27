using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.Services.Common;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using ModuloCongresso.Infra.Data.Interfaces;
using System;
using System.Linq;
using AutoMapper;
using ModuloCongresso.Application.AutoMapper;
using ModuloCongresso.Application.ViewModels;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Services;
using ModuloCongresso.Domain.Interfaces.Services.Business;
using ModuloCongresso.Infra.CrossCutting.MvcFilters;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Services
{
    public class CotacaoAppService : AppService, ICotacaoAppService
    {
        private readonly ICotacaoService _cotacaoService;
        private readonly ICalculoService _calculoService;
        private readonly IItemService _itemService;
        private readonly IQuestionarioService _questionarioService;
        private readonly IPerfilService _perfilService;
        private readonly IClienteService _clienteService;
        private readonly ICoberturaItemService _coberturaItemService;
        private readonly ICoberturaService _coberturaService;
        private readonly IEnderecoService _enderecoService;

        public CotacaoAppService(ICotacaoService cotacaoService, IUnitOfWork unitOfWork, 
            ICalculoService calculoService,
            IItemService itemService,
            IQuestionarioService questionarioService,
            IPerfilService perfilService,
            IClienteService clienteService,
            ICoberturaItemService coberturaItemService,
            ICoberturaService coberturaService,
            IEnderecoService enderecoService)
            : base(unitOfWork)
        {
            _cotacaoService = cotacaoService;
            _calculoService = calculoService;
            _itemService = itemService;
            _questionarioService = questionarioService;
            _perfilService = perfilService;
            _clienteService = clienteService;
            _coberturaItemService = coberturaItemService;
            _coberturaService = coberturaService;
            _enderecoService = enderecoService;
        }

        public CotacaoViewModel Adicionar(CotacaoViewModel cotacaoViewModel)
        {
            var cotacao = Mapper.Map<Cotacao>(cotacaoViewModel);
            var item = new Item();
            MapearItem(item, cotacaoViewModel.Item, cotacaoViewModel);
            var perfil = new Perfil();
            MapearPerfil(perfil, cotacaoViewModel.Perfil, cotacaoViewModel);
            var questionario = Mapper.Map<Questionario>(cotacaoViewModel.Questionario);
            questionario.CotacaoId = cotacaoViewModel.CotacaoId;
            var cliente = Mapper.Map<Cliente>(cotacaoViewModel.Cliente);
            cliente.CotacaoId = cotacaoViewModel.CotacaoId;
            var endereco = Mapper.Map<Endereco>(cotacaoViewModel.Cliente);

            cliente.Enderecos.Add(endereco);
            cotacao.Clientes.Add(cliente);
            cotacao.Itens.Add(item);
            cotacao.Perfils.Add(perfil);
            cotacao.Questionarios.Add(questionario);

            foreach (var itemCobertura in cotacaoViewModel.Item.ListCoberturasItem)
            {
                itemCobertura.ItemId = item.ItemId;
                item.Coberturas.Add(new SelectedCoberturaViewModelToCoberturaItem().Map(itemCobertura));
            }

            BeginTransaction();

            cotacao.PremioTotal = _calculoService.CalcularPremio(cotacao, item, perfil, questionario);

            var cotacaoReturn = _cotacaoService.Adicionar(cotacao);

            if (cotacaoReturn.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<CotacaoViewModel>(cotacaoReturn);
        }

        public CotacaoViewModel ObterCotacaoPorId(int cotacaoId)
        {
            var cotacao = _cotacaoService.ObterCotacaoPorId(cotacaoId);

            var cotacaoViewModel = Mapper.Map<CotacaoViewModel>(cotacao);

            cotacaoViewModel.Item = new SelectedItemToItemViewModel().Map(_itemService.ObterItemCotacao(cotacaoId));
            cotacaoViewModel.Perfil = new SelectedPerfilToPerfilViewModel().Map(_perfilService.ObterPerfilCotacao(cotacaoId));
            cotacaoViewModel.Questionario = Mapper.Map<QuestionarioViewModel>(_questionarioService.ObterQuestionarioCotacao(cotacaoId));
            cotacaoViewModel.Cliente = new SelectedEnderecoToClienteEnderecoViewModel(_clienteService, _enderecoService).Map(cotacaoViewModel.CotacaoId);

            return cotacaoViewModel;
        }

        private static void MapearPerfil(Perfil perfil, PerfilViewModel perfilViewModel, CotacaoViewModel cotacaoViewModel)
        {
            perfil.CpfPrincipalCondutor = perfilViewModel.CpfPrincipalCondutor;
            perfil.DataNascPrincipalCondutor = perfilViewModel.DataNascPrincipalCondutor;
            perfil.EstadoCivilId = perfilViewModel.EstadoCivilId;
            perfil.FlagPontosCarteira = perfilViewModel.FlagPontosCarteira;
            perfil.FlagResideMenorIdade = perfilViewModel.FlagResideMenorIdade;
            perfil.FlagSegPrincipalCondutor = perfilViewModel.FlagSegPrincipalCondutor;
            perfil.NomePrincipalCondutor = perfilViewModel.NomePrincipalCondutor;
            perfil.PerfilId = perfilViewModel.PerfilId;
            perfil.QuantidadeVeicResidencia = perfilViewModel.QuantidadeVeicResidencia;
            perfil.TempoHabilitacaoId = perfilViewModel.TempoHabilitacaoId;
            perfil.TipoResidenciaId = perfilViewModel.TipoResidenciaId;
            perfil.SexoId = perfilViewModel.SexoId;
            perfil.DistanciaResidenciaTrabalhoId = perfilViewModel.DistanciaTrabalhoId;
            perfil.CotacaoId = cotacaoViewModel.CotacaoId;
        }

        private static void MapearItem(Item item, ItemViewModel itemViewModel, CotacaoViewModel cotacaoViewModel)
        {
            item.ImpostoId = itemViewModel.ImpostoId;
            item.UsoId = itemViewModel.UsoId;
            item.CotacaoId = cotacaoViewModel.CotacaoId;
            item.ModeloId = itemViewModel.ModeloId;
            item.ProdutoId = itemViewModel.ProdutoId;
            item.FlagRemarcado = itemViewModel.FlagRemarcado;
            item.NumChassi = itemViewModel.NumChassi;
        }

        public string ObterDescricaoModeloCotacao(int cotacaoId)
        {
            return _cotacaoService.ObterDescricaoModeloCotacao(cotacaoId);
        }

        public IEnumerable<CotacaoViewModel> ObterCotacoesPorUsuario(Guid userId)
        {
            var cotacoes = Mapper.Map<IEnumerable<CotacaoViewModel>>(_cotacaoService.ObterCotacoesPorUsuario(userId));

            var obterCotacoesPorUsuario = cotacoes as IList<CotacaoViewModel> ?? cotacoes.ToList();
            foreach (var cotacao in obterCotacoesPorUsuario)
            {
                cotacao.Descricao = ObterDescricaoModeloCotacao(cotacao.CotacaoId);
            }

            return obterCotacoesPorUsuario;
        }

        public void Dispose()
        {
            _cotacaoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
