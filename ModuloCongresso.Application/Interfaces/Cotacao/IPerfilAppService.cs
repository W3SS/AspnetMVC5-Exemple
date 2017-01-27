using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface IPerfilAppService : IDisposable
    {
        IEnumerable<PerfilViewModel> ObterTodos();

        PerfilViewModel ObterPerfilCotacao(int cotacaoId);
    }
}