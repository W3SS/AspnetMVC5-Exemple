using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class SexoService : ISexoService
    {
        private readonly ISexoRepository _sexoRepository;

        public SexoService(ISexoRepository sexoRepository)
        {
            _sexoRepository = sexoRepository;
        }

        public void Dispose()
        {
            _sexoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Sexo> ObterTodos()
        {
            return _sexoRepository.ObterTodos();
        }
    }
}