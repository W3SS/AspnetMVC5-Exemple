using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface ICoberturaService : IDisposable
    {
        IEnumerable<Coberturas> ObterTodos();

        IEnumerable<Coberturas> ObterCoberturasProdutos(int produto);
    }
}