using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface ITipoSeguroAppService : IDisposable
    {
        IEnumerable<TipoSeguroViewModel> ObterTodos();
    }
}