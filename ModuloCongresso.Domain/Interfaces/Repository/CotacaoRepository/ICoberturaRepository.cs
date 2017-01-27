using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface ICoberturaRepository : IRepository<Coberturas>
    {
        IEnumerable<Coberturas> ObterCoberturasProdutos(int produto);
    }
}