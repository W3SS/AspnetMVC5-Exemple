﻿using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IQuestionarioService : IDisposable
    {
        IEnumerable<Questionario> ObterTodos();

        Questionario ObterQuestionarioCotacao(int cotacaoId);
    }
}