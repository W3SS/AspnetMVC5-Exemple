using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class CoberturaService : ICoberturaService
    {
        private readonly ICoberturaRepository _coberturaRepository;

        public CoberturaService(ICoberturaRepository coberturaRepository)
        {
            _coberturaRepository = coberturaRepository;
        }

        public void Dispose()
        {
            _coberturaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        
        public IEnumerable<Coberturas> ObterCoberturasProdutos(int produto)
        {
            return _coberturaRepository.ObterCoberturasProdutos(produto);
        }

        public IEnumerable<Coberturas> ObterTodos()
        {
            return _coberturaRepository.ObterTodos();
        }
    }
}