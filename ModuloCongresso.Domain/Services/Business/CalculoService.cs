using System;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Services.Business;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.Business
{
    public class CalculoService : ICalculoService
    {
        private readonly ICoberturasProdutoService _coberturasProdutoService;

        public CalculoService(ICoberturasProdutoService coberturasProdutoService)
        {
            _coberturasProdutoService = coberturasProdutoService;
        }

        public decimal CalcularPremio(Cotacao cotacao, Item item, Perfil perfil, Questionario questionario)
        {
            double premio = 0;
            double premioMinimo = 1000;

            foreach (var coberturas in item.Coberturas)
            {
                if (!(Math.Abs(coberturas.Valor) > 0))
                    continue;

                var valor = coberturas.Valor * _coberturasProdutoService.ObterTaxaCoberturaProduto(item.ProdutoId, coberturas.CoberturaId);
                premio = premio + valor;
            }

            premio = premio + premioMinimo;

            return new decimal(premio);
        }
    }
}