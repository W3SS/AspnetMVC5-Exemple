using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface ICoberturasProdutoRepository : IRepository<CoberturasProduto>
    {
        IEnumerable<CoberturasProduto> ObterCoberturasProdutos(int produto);

        CoberturasProduto ObterCoberturaProdutos(int produto, int coberturaId);
    }
}