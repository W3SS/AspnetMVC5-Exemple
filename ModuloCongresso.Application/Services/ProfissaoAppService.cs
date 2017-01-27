using ModuloCongresso.Application.Interfaces;
using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels;
using ModuloCongresso.Infra.Data.Repository;
using AutoMapper;
using ModuloCongresso.Domain.Interfaces.Services;

namespace ModuloCongresso.Application
{
    public class ProfissaoAppService : IProfissaoAppService
    {
        private readonly IProfissaoService _profissaoService;

        public ProfissaoAppService(IProfissaoService profissaoService)
        {
            _profissaoService = profissaoService;
        }

        public IEnumerable<ProfissaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProfissaoViewModel>>(_profissaoService.ObterTodos());
        }

        public void Dispose()
        {
            _profissaoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
