using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class SexoAppService : ISexoAppService
    {
        private readonly ISexoService _sexoService;

        public SexoAppService(ISexoService sexoService)
        {
            _sexoService = sexoService;
        }

        public void Dispose()
        {
            _sexoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SexoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<SexoViewModel>>(_sexoService.ObterTodos());
        }
    }
}