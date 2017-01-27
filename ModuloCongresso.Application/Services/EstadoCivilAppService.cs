using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class EstadoCivilAppService : IEstadoCivilAppService
    {
        private readonly IEstadoCivilService _estadoCivilService;

        public EstadoCivilAppService(IEstadoCivilService estadoCivilService)
        {
            _estadoCivilService = estadoCivilService;
        }

        public IEnumerable<EstadoCivilViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EstadoCivilViewModel>>(_estadoCivilService.ObterTodos());
        }

        public void Dispose()
        {
            _estadoCivilService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}