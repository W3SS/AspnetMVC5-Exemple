using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface ICoberturasProdutoService : IDisposable
    {
        IEnumerable<CoberturasProduto> ObterTodos();

        IEnumerable<CoberturasProduto> ObterCoberturasProdutos(int produto);

        double ObterTaxaCoberturaProduto(int produto, int coberturaId);

        CoberturasProduto ObterCoberturaProdutos(int produto, int coberturaId);

        int ObterIdCoberturaBasica(int produto);
    }
}