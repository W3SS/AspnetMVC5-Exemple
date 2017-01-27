using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class AntiFurtoService : IAntiFurtoService
    {
        private readonly IAntiFurtoRepository _antiFurtoRepository;

        public AntiFurtoService(IAntiFurtoRepository antiFurtoRepository)
        {
            _antiFurtoRepository = antiFurtoRepository;
        }

        public IEnumerable<AntiFurto> ObterTodos()
        {
            return _antiFurtoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _antiFurtoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}