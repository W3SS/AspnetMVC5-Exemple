using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using System;
using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class CotacaoService : ICotacaoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IItemService _itemService;
        private readonly IModeloService _modeloService;

        public CotacaoService(ICotacaoRepository cotacaoRepository, IItemService itemService, IModeloService modeloService)
        {
            _cotacaoRepository = cotacaoRepository;
            _itemService = itemService;
            _modeloService = modeloService;
        }

        public void Dispose()
        {
            _cotacaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Cotacao Adicionar(Cotacao cotacao)
        {
            if (!cotacao.IsValid())
                return cotacao;

            //cotacao.ValidationResult = new CotacaoAptoParaCadastroValidation(_cotacaoRepository).Validate(cotacao);
            //if (!cotacao.ValidationResult.IsValid)
            //    return cotacao;

            return _cotacaoRepository.Adicionar(cotacao);
        }

        public string ObterDescricaoModeloCotacao(int cotacaoId)
        {
            var modeloId = _itemService.ObterItemCotacao(cotacaoId).ModeloId;

            return _modeloService.ObterDescricaoModelo(modeloId) ?? string.Empty;
        }

        public Cotacao ObterCotacaoPorId(int cotacaoId)
        {
            return _cotacaoRepository.ObterCotacaoPorId(cotacaoId);
        }

        public IEnumerable<Cotacao> ObterCotacoesPorUsuario(Guid userId)
        {
            return _cotacaoRepository.ObterCotacoesPorUsuario(userId);
        }

        public decimal ObterPremioCotacao(int cotacaoId)
        {
            var cotacao = _cotacaoRepository.ObterCotacaoPorId(cotacaoId);

            return cotacao.PremioTotal;
        }

        public Cotacao Validar(Cotacao cotacao)
        {
            cotacao.IsValid();
            return cotacao;
        }
    }
}
