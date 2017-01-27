using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class DistanciaTrabalhoService : IDistanciaTrabalhoService
    {
        private readonly IDistanciaTrabalhoRepository _distanciaTrabalhoRepository;

        public DistanciaTrabalhoService(IDistanciaTrabalhoRepository distanciaTrabalhoRepository)
        {
            _distanciaTrabalhoRepository = distanciaTrabalhoRepository;
        }

        public void Dispose()
        {
            _distanciaTrabalhoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DistanciaTrabalho> ObterTodos()
        {
            return _distanciaTrabalhoRepository.ObterTodos();
        }
    }
}