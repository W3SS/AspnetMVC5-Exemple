using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface ICotacaoRepository : IRepository<Cotacao>
    {
        Cotacao ObterCotacaoPorId(int cotacaoId);

        IEnumerable<Cotacao> ObterCotacoesPorUsuario(Guid userId);
    }
}
