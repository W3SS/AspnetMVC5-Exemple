using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class CotacaoViewModel
    {
        public CotacaoViewModel()
        {
            CotacaoId = int.Parse(GeneratorNumber());
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        #region Cotação
        [Key]
        public int CotacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Tipo de Cálculo")]
        public int TipoCalculoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Tipo de Seguro")]
        public int TipoSeguroId { get; set; }

        public decimal PremioTotal { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCalculo { get; set; }

        [Display(Name = "Vigência Inicial")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        public DateTime DataVigenciaInicial { get; set; }

        [Display(Name = "Vigência Final")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        public DateTime DataVigenciaFinal { get; set; }

        public List<ModeloViewModel> ListModelos { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Tipo de Cálculo")]
        public IEnumerable<SelectListItem> TiposCalculo { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Tipo de Seguro")]
        public IEnumerable<SelectListItem> TiposSeguro { get; set; }

        [ScaffoldColumn(false)]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }
        #endregion

        public virtual ClienteEnderecoViewModel Cliente { get; set; }
        public virtual ItemViewModel Item { get; set; }
        public virtual PerfilViewModel Perfil { get; set; }
        public virtual QuestionarioViewModel Questionario { get; set; }

        public List<CoberturasViewModel> ListCoberturas { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<CoberturaItemViewModel> SelectedCoberturas { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

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
