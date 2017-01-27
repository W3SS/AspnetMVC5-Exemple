using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class TipoSeguroAppService : ITipoSeguroAppService
    {
        private readonly ITipoSeguroService _tipoSeguroService;

        public TipoSeguroAppService(ITipoSeguroService tipoSeguroService)
        {
            _tipoSeguroService = tipoSeguroService;
        }

        public IEnumerable<TipoSeguroViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoSeguroViewModel>>(_tipoSeguroService.ObterTodos());
        }

        public void Dispose()
        {
            _tipoSeguroService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}