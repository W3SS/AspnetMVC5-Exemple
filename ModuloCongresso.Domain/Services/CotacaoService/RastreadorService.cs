using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class RastreadorService : IRastreadorService
    {
        private readonly IRastreadorRepository _rastreadorRepository;

        public RastreadorService(IRastreadorRepository rastreadorRepository)
        {
            _rastreadorRepository = rastreadorRepository;
        }

        public IEnumerable<Rastreador> ObterTodos()
        {
            return _rastreadorRepository.ObterTodos();
        }

        public void Dispose()
        {
            _rastreadorRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}