using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface ICoberturaAppService : IDisposable
    {
        IEnumerable<CoberturasViewModel> ObterTodos();

        IEnumerable<CoberturasViewModel> ObterCoberturasProdutos(int produto);

        int ObterIdCoberturaBasica(int produto);
    }
}