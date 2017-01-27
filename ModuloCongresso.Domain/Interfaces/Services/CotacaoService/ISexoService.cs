﻿using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface ISexoService : IDisposable
    {
        IEnumerable<Sexo> ObterTodos();
    }
}