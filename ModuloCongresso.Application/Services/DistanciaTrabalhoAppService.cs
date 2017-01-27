using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class DistanciaTrabalhoAppService : IDistanciaTrabalhoAppService
    {
        private readonly IDistanciaTrabalhoService _distanciaTrabalhoService;

        public DistanciaTrabalhoAppService(IDistanciaTrabalhoService distanciaTrabalhoService)
        {
            _distanciaTrabalhoService = distanciaTrabalhoService;
        }

        public void Dispose()
        {
            _distanciaTrabalhoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DistanciaTrabalhoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<DistanciaTrabalhoViewModel>>(_distanciaTrabalhoService.ObterTodos());
        }
    }
}