using System;
using ModuloCongresso.Application.ViewModels.Cotacao;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface ITipoCalculoAppService : IDisposable
    {
        IEnumerable<TipoCalculoViewModel> ObterTodos();

        string ObterDataVigenciaFinal(int tipoCalculoId, string dataVigenciaInicial);
    }
}