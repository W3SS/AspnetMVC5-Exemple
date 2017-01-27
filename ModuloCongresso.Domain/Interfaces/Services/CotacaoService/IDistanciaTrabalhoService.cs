using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IDistanciaTrabalhoService : IDisposable
    {
        IEnumerable<DistanciaTrabalho> ObterTodos();
    }
}