using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> ObterTodos()
        {
            return _itemRepository.ObterTodos();
        }

        public Item ObterItemCotacao(int cotacaoId)
        {
            return _itemRepository.ObterItemCotacao(cotacaoId);
        }

        public int ObterModeloItem(int cotacaoId)
        {
            return ObterItemCotacao(cotacaoId).ModeloId;
        }

        public void Dispose()
        {
            _itemRepository.Dispose();
            GC.SuppressFinalize(this); 
        }
    }
}