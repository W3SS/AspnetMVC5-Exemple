using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}