using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class TipoResidenciaAppService : ITipoResidenciaAppService
    {
        private readonly ITipoResidenciaService _tipoResidenciaService;

        public TipoResidenciaAppService(ITipoResidenciaService tipoResidenciaService)
        {
            _tipoResidenciaService = tipoResidenciaService;
        }

        public IEnumerable<TipoResidenciaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoResidenciaViewModel>>(_tipoResidenciaService.ObterTodos());
        }

        public void Dispose()
        {
            _tipoResidenciaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}