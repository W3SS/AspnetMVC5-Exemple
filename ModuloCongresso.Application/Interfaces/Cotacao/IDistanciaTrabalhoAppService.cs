using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface IDistanciaTrabalhoAppService : IDisposable
    {
        IEnumerable<DistanciaTrabalhoViewModel> ObterTodos();
    }
}