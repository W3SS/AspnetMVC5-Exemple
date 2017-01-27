using ModuloCongresso.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Interfaces
{
    public interface IProfissaoAppService : IDisposable
    {
        IEnumerable<ProfissaoViewModel> ObterTodos();
    }
}
