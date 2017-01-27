using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class TempoHabilitacaoAppService : ITempoHabilitacaoAppService
    {
        private readonly ITempoHabilitacaoService _tempoHabilitacaoService;

        public TempoHabilitacaoAppService(ITempoHabilitacaoService tempoHabilitacaoService)
        {
            _tempoHabilitacaoService = tempoHabilitacaoService;
        }

        public void Dispose()
        {
            _tempoHabilitacaoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TempoHabilitacaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TempoHabilitacaoViewModel>>(_tempoHabilitacaoService.ObterTodos());
        }
    }
}