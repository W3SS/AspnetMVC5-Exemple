using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using ModuloCongresso.Infra.CrossCutting.MvcFilters;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            ItemId = int.Parse(GeneratorNumber());
            ProdutoId = (int)Produtos.Automóvel;
            ListCoberturasItem = new List<CoberturaItemViewModel>();
        }

        [Key]
        public int ItemId { get; set; }

        [ScaffoldColumn(false)]
        public int CotacaoId { get; set; }

        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha as Informações do Veículo")]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Uso")]
        public int UsoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Isenção de Imposto")]
        public int ImpostoId { get; set; }

        public long? NumChassi { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Chassi Remarcado?")]
        public bool FlagRemarcado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Uso?")]
        public IEnumerable<SelectListItem> Uso { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Isenção de Imposto?")]
        public IEnumerable<SelectListItem> Imposto { get; set; }

        public virtual ModeloViewModel Modelo { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }

        public List<CoberturaItemViewModel> ListCoberturasItem { get; set; }

        public static string GeneratorNumber()
        {
            var chars = "0123456789";
            int tamanho = 8;
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
    }
}