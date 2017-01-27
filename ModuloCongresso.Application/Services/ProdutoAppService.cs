using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.ObterTodos());
        }

        public void Dispose()
        {
            _produtoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
