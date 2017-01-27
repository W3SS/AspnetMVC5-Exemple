using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class RastreadorAppService : IRastreadorAppService
    {
        private readonly IRastreadorService _rastreadorService;

        public RastreadorAppService(IRastreadorService rastreadorService)
        {
            _rastreadorService = rastreadorService;
        }

        public IEnumerable<RastreadorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RastreadorViewModel>>(_rastreadorService.ObterTodos());
        }

        public void Dispose()
        {
            _rastreadorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}