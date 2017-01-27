using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Application.AutoMapper
{
    public class SelectedItemToItemViewModel
    {
        public ItemViewModel Map(Item item)
        {
            var viewModel = new ItemViewModel();
            {
                viewModel.ImpostoId = item.ImpostoId;
                viewModel.UsoId = item.UsoId;
                viewModel.CotacaoId = item.CotacaoId;
                viewModel.ModeloId = item.ModeloId;
                viewModel.ProdutoId = item.ProdutoId;
                viewModel.FlagRemarcado = item.FlagRemarcado;
                viewModel.NumChassi = item.NumChassi;
            };

            return viewModel;
        }
    }
}