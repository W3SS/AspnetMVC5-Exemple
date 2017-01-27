using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface ICotacaoAppService : IDisposable
    {
        CotacaoViewModel Adicionar(CotacaoViewModel cotacaoViewModel);

        string ObterDescricaoModeloCotacao(int cotacaoId);

        CotacaoViewModel ObterCotacaoPorId(int cotacaoId);

        IEnumerable<CotacaoViewModel> ObterCotacoesPorUsuario(Guid userId);
    }
}
