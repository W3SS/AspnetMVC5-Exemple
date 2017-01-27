using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class ImpostoAppService : IImpostoAppService
    {
        private readonly IImpostoService _impostoService;

        public ImpostoAppService(IImpostoService impostoService)
        {
            _impostoService = impostoService;
        }

        public void Dispose()
        {
            _impostoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ImpostoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ImpostoViewModel>>(_impostoService.ObterTodos());
        }
    }
}