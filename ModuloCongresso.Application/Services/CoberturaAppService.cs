using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class CoberturaAppService : ICoberturaAppService
    {
        private readonly ICoberturaService _coberturaService;
        private readonly ICoberturasProdutoService _coberturasProdutoService;

        public CoberturaAppService(ICoberturaService coberturaService, ICoberturasProdutoService coberturasProdutoService)
        {
            _coberturaService = coberturaService;
            _coberturasProdutoService = coberturasProdutoService;
        }

        public void Dispose()
        {
            _coberturaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CoberturasViewModel> ObterCoberturasProdutos(int produto)
        {
            return Mapper.Map<IEnumerable<CoberturasViewModel>>(_coberturaService.ObterCoberturasProdutos(produto));
        }

        public IEnumerable<CoberturasViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CoberturasViewModel>>(_coberturaService.ObterTodos());
        }

        public int ObterIdCoberturaBasica(int produto)
        {
            return _coberturasProdutoService.ObterIdCoberturaBasica(produto);
        }
    }
}