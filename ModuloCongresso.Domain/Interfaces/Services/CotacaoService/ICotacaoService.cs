using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface ICotacaoService : IDisposable
    {
        Cotacao Adicionar(Cotacao cotacao);

        string ObterDescricaoModeloCotacao(int cotacaoId);

        Cotacao ObterCotacaoPorId(int cotacaoId);

        IEnumerable<Cotacao> ObterCotacoesPorUsuario(Guid userId);

        decimal ObterPremioCotacao(int cotacaoId);

        Cotacao Validar(Cotacao cotacao);
    }
}
