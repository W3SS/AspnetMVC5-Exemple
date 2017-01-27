﻿using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IPerfilService : IDisposable
    {
        IEnumerable<Perfil> ObterTodos();

        Perfil ObterPerfilCotacao(int cotacaoId);
    }
}