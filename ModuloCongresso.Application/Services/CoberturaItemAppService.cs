using System;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class CoberturaItemAppService : ICoberturaItemAppService
    {
        private readonly ICoberturaItemService _coberturaItemService;

        public CoberturaItemAppService(ICoberturaItemService coberturaItemService)
        {
            _coberturaItemService = coberturaItemService;
        }

        public void Dispose()
        {
            _coberturaItemService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}