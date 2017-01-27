using ModuloCongresso.Application.Interfaces;
using ModuloCongresso.Domain.Interfaces.Services;
using ModuloCongresso.Application.ViewModels;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace ModuloCongresso.Application
{
    public class PaisResidenciaAppService : IPaisResidenciaAppService
    {
        private readonly IPaisResidenciaService _paisResidenciaService;

        public PaisResidenciaAppService(IPaisResidenciaService paisResidenciaService)
        {
            _paisResidenciaService = paisResidenciaService;
        }

        public IEnumerable<PaisResidenciaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PaisResidenciaViewModel>>(_paisResidenciaService.ObterTodos());
        }

        public void Dispose()
        {
            _paisResidenciaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
