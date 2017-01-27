using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemService _itemService;

        public ItemAppService(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IEnumerable<ItemViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ItemViewModel>>(_itemService.ObterTodos());
        }

        public ItemViewModel ObterItemCotacao(int cotacaoId)
        {
            return Mapper.Map<ItemViewModel>(_itemService.ObterItemCotacao(cotacaoId));
        }

        public void Dispose()
        {
            _itemService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}