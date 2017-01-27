using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using System;
using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IItemService _itemService;
        private readonly IModeloService _modeloService;

        public MarcaService(IMarcaRepository marcaRepository, IItemService itemService, IModeloService modeloService)
        {
            _marcaRepository = marcaRepository;
            _itemService = itemService;
            _modeloService = modeloService;
        }

        public IEnumerable<Marca> ObterTodos()
        {
            return _marcaRepository.ObterTodos();
        }

        public IEnumerable<Marca> ObterTodosOrdenadoAlfabeticamente()
        {
            IEnumerable<Marca> query = _marcaRepository.ObterTodos().OrderBy(m => m.Nome);

            return query;
        }

        public Marca ObterMarcaPorId(int marcaId)
        {
            return _marcaRepository.ObterMarcaPorId(marcaId);
        }
        
        public int ObterMarcaPorModeloCotacao(int cotacaoId)
        {
            var modeloId = _itemService.ObterModeloItem(cotacaoId);

            return _modeloService.ObterIdMarcaPorModelo(modeloId);
        }

        public void Dispose()
        {
            _marcaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
