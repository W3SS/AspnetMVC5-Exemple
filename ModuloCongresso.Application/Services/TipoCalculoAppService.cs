using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class TipoCalculoAppService : ITipoCalculoAppService
    {
        private readonly ITipoCalculoService _tipoCalculoService;

        public TipoCalculoAppService(ITipoCalculoService tipoCalculoService)
        {
            _tipoCalculoService = tipoCalculoService;
        }

        public IEnumerable<TipoCalculoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoCalculoViewModel>>(_tipoCalculoService.ObterTodos());
        }

        public string ObterDataVigenciaFinal(int tipoCalculoId, string dataVigenciaInicial)
        {
            return _tipoCalculoService.ObterDataVigenciaFinal(tipoCalculoId, dataVigenciaInicial);
        }

        public void Dispose()
        {
            _tipoCalculoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}