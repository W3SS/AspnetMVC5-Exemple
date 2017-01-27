using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.ViewModels.Business
{
    public class ManageCotacaoViewModel
    {
        public List<CotacaoViewModel> ListCotacoes { get; set; }

        public string Produto { get; set; }
    }
}