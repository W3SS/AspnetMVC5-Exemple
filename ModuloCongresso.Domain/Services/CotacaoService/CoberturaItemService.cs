using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class CoberturaItemService : ICoberturaItemService
    {
        private readonly ICoberturaItemRepository _coberturaItemRepository;

        public CoberturaItemService(ICoberturaItemRepository coberturaItemRepository)
        {
            _coberturaItemRepository = coberturaItemRepository;
        }

        public void Dispose()
        {
            _coberturaItemRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CoberturasItem> ObterCoberturasItems(int itemId)
        {
            return _coberturaItemRepository.ObterCoberturasItems(itemId);
        }
    }
}