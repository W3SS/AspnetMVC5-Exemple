using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class ImpostoService : IImpostoService
    {
        private readonly IImpostoRepository _impostoRepository;

        public ImpostoService(IImpostoRepository impostoRepository)
        {
            _impostoRepository = impostoRepository;
        }

        public void Dispose()
        {
            _impostoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Imposto> ObterTodos()
        {
            return _impostoRepository.ObterTodos();
        }
    }
}