using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class UsoService : IUsoService
    {
        private readonly IUsoRepository _usoRepository;

        public UsoService(IUsoRepository usoRepository)
        {
            _usoRepository = usoRepository;
        }

        public void Dispose()
        {
            _usoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Uso> ObterTodos()
        {
            return _usoRepository.ObterTodos();
        }
    }
}