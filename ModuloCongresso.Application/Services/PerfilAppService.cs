using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class PerfilAppService : IPerfilAppService
    {
        private readonly IPerfilService _perfilService;

        public PerfilAppService(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        public IEnumerable<PerfilViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PerfilViewModel>>(_perfilService.ObterTodos());
        }

        public PerfilViewModel ObterPerfilCotacao(int cotacaoId)
        {
            return Mapper.Map<PerfilViewModel>(_perfilService.ObterPerfilCotacao(cotacaoId));
        }

        public void Dispose()
        {
            _perfilService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}