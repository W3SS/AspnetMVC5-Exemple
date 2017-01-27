using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class TipoResidenciaService : ITipoResidenciaService
    {
        private readonly ITipoResidenciaRepository _tipoResidenciaRepository;

        public TipoResidenciaService(ITipoResidenciaRepository tipoResidenciaRepository)
        {
            _tipoResidenciaRepository = tipoResidenciaRepository;
        }

        public IEnumerable<TipoResidencia> ObterTodos()
        {
            return _tipoResidenciaRepository.ObterTodos();
        }

        public void Dispose()
        {
            _tipoResidenciaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}