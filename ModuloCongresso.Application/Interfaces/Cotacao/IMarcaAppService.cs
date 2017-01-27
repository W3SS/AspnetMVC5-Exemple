using ModuloCongresso.Application.ViewModels.Cotacao;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface IMarcaAppService : IDisposable
    {
        IEnumerable<MarcaViewModel> ObterTodos();

        IEnumerable<MarcaViewModel> ObterTodosOrdenadoAlfabeticamente();

        MarcaViewModel ObterMarcaPorId(int marcaId);

        int ObterMarcaPorModeloCotacao(int cotacaoId);
    }
}
