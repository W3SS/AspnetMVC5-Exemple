using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services
{
    public interface IProfissaoService : IDisposable
    {
        IEnumerable<Profissao> ObterTodos();
    }
}
