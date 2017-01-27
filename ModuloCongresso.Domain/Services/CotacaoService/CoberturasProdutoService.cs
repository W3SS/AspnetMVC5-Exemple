using System;
using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class CoberturasProdutoService : ICoberturasProdutoService
    {
        private readonly ICoberturasProdutoRepository _coberturasProdutoRepository;

        public CoberturasProdutoService(ICoberturasProdutoRepository coberturasProdutoRepository)
        {
            _coberturasProdutoRepository = coberturasProdutoRepository;
        }

        public void Dispose()
        {
            _coberturasProdutoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CoberturasProduto> ObterTodos()
        {
            return _coberturasProdutoRepository.ObterTodos();
        }

        public IEnumerable<CoberturasProduto> ObterCoberturasProdutos(int produto)
        {
            return _coberturasProdutoRepository.ObterCoberturasProdutos(produto);
        }

        public double ObterTaxaCoberturaProduto(int produto, int coberturaId)
        {
            return ObterCoberturaProdutos(produto, coberturaId).Taxa;
        }

        public CoberturasProduto ObterCoberturaProdutos(int produto, int coberturaId)
        {
            return _coberturasProdutoRepository.ObterCoberturaProdutos(produto, coberturaId);
        }

        public int ObterIdCoberturaBasica(int produto)
        {
            var coberturas = ObterCoberturasProdutos(produto);
            var coberturaBasicaId = 0;

            foreach (var cob in coberturas.Where(cob => cob.FlagBasica))
            {
                coberturaBasicaId = cob.CoberturaId;
            }

            return coberturaBasicaId;
        }
    }
}