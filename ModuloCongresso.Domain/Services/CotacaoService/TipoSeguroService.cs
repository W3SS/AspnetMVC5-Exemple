using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class TipoSeguroService : ITipoSeguroService
    {
        private readonly ITipoSeguroRepository _tipoSeguroRepository;

        public TipoSeguroService(ITipoSeguroRepository tipoSeguroRepository)
        {
            _tipoSeguroRepository = tipoSeguroRepository;
        }

        public IEnumerable<TipoSeguro> ObterTodos()
        {
            return _tipoSeguroRepository.ObterTodos();
        }

        public void Dispose()
        {
            _tipoSeguroRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}