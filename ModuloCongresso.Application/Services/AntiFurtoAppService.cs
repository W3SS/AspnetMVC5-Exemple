using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class AntiFurtoAppService : IAntiFurtoAppService
    {
        private readonly IAntiFurtoService _antiFurtoService;

        public AntiFurtoAppService(IAntiFurtoService antiFurtoService)
        {
            _antiFurtoService = antiFurtoService;
        }

        public IEnumerable<AntiFurtoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AntiFurtoViewModel>>(_antiFurtoService.ObterTodos());
        }

        public void Dispose()
        {
            _antiFurtoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}