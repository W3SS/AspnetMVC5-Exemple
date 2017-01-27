using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Application.AutoMapper
{
    public class SelectedCoberturaViewModelToCoberturaItem
    {
        public CoberturasItem Map(CoberturaItemViewModel viewModel)
        {
            var cobertura = new CoberturasItem
            {
                ItemId = viewModel.ItemId,
                CoberturaId = viewModel.CoberturaId,
                CoberturasItemId = viewModel.CoberturasItemId,
                Valor = viewModel.Valor
            };

            return cobertura;
        }
    }
}