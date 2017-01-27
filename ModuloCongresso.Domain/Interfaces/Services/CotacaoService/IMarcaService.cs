using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IMarcaService : IDisposable
    {
        IEnumerable<Marca> ObterTodos();

        IEnumerable<Marca> ObterTodosOrdenadoAlfabeticamente();

        Marca ObterMarcaPorId(int marcaId);

        int ObterMarcaPorModeloCotacao(int cotacaoId);
    }
}
