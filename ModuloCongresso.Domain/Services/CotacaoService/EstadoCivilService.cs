using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class EstadoCivilService : IEstadoCivilService
    {
        private readonly IEstadoCivilRepository _estadoCivilRepository;

        public EstadoCivilService(IEstadoCivilRepository estadoCivilRepository)
        {
            _estadoCivilRepository = estadoCivilRepository;
        }

        public IEnumerable<EstadoCivil> ObterTodos()
        {
            return _estadoCivilRepository.ObterTodos();
        }

        public void Dispose()
        {
            _estadoCivilRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}