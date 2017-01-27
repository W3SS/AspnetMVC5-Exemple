using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Services
{
    public class MarcaAppService : IMarcaAppService
    {
        private readonly IMarcaService _marcaService;

        public MarcaAppService(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        public IEnumerable<MarcaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<MarcaViewModel>>(_marcaService.ObterTodos());
        }

        public IEnumerable<MarcaViewModel> ObterTodosOrdenadoAlfabeticamente()
        {
            return Mapper.Map<IEnumerable<MarcaViewModel>>(_marcaService.ObterTodosOrdenadoAlfabeticamente());
        }

        public MarcaViewModel ObterMarcaPorId(int marcaId)
        {
            return Mapper.Map<MarcaViewModel>(_marcaService.ObterMarcaPorId(marcaId));
        }

        public int ObterMarcaPorModeloCotacao(int cotacaoId)
        {
            return _marcaService.ObterMarcaPorModeloCotacao(cotacaoId);
        }

        public void Dispose()
        {
            _marcaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
