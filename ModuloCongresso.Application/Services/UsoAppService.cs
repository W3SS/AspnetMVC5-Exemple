using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class UsoAppService : IUsoAppService
    {
        private readonly IUsoService _usoService;

        public UsoAppService(IUsoService usoService)
        {
            _usoService = usoService;
        }

        public void Dispose()
        {
            _usoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<UsoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsoViewModel>>(_usoService.ObterTodos());
        }
    }
}