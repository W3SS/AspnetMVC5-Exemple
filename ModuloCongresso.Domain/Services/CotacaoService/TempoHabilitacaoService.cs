using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class TempoHabilitacaoService : ITempoHabilitacaoService
    {
        private readonly ITempoHabilitacaoRepository _tempoHabilitacaoRepository;

        public TempoHabilitacaoService(ITempoHabilitacaoRepository tempoHabilitacaoRepository)
        {
            _tempoHabilitacaoRepository = tempoHabilitacaoRepository;
        }

        public void Dispose()
        {
            _tempoHabilitacaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TempoHabilitacao> ObterTodos()
        {
            return _tempoHabilitacaoRepository.ObterTodos();
        }
    }
}