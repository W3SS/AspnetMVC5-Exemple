﻿using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IProdutoService : IDisposable
    {
        IEnumerable<Produto> ObterTodos();
    }
}