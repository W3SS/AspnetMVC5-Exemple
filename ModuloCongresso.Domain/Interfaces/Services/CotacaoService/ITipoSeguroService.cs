using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface ITipoSeguroService : IDisposable
    {
        IEnumerable<TipoSeguro> ObterTodos();
    }
}