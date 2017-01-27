﻿using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface IItemAppService : IDisposable
    {
        IEnumerable<ItemViewModel> ObterTodos();

        ItemViewModel ObterItemCotacao(int cotacaoId);
    }
}