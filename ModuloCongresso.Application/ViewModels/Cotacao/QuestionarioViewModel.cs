using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class QuestionarioViewModel
    {
        public QuestionarioViewModel()
        {
            QuestionarioId = int.Parse(GeneratorNumber());
        }

        [Key]
        public int QuestionarioId { get; set; }

        [ScaffoldColumn(false)]
        public int CotacaoId { get; set; }

        public int? RastreadorId { get; set; }

        public int? AntiFurtoId { get; set; }

        [Display(Name = "CEP onde o veículo pernoita?")]
        [Required(ErrorMessage = "Preencha o Campo CEP onde o veículo pernoita?")]
        [MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string CepPernoite { get; set; }

        [Display(Name = "Relação do Segurado com o Proprietário Legal do Veículo?")]
        [Required(ErrorMessage = "Preencha o Campo Relação do Segurado com o Proprietário Legal do Veículo?")]
        public string RelacaoSegurado { get; set; }

        [Display(Name = "Veículo blindado?")]
        [Required(ErrorMessage = "Preencha o Campo Veículo blindado?")]
        public bool FlagBlindado { get; set; }

        [Display(Name = "Veículo adaptado para deficiente físico?")]
        [Required(ErrorMessage = "Preencha o Campo Veículo adaptado para deficiente físico?")]
        public bool FlagAdaptadoDeficiente { get; set; }

        [Display(Name = "Possui Kit Gás?")]
        [Required(ErrorMessage = "Preencha o Campo Possui Kit Gás?")]
        public bool FlagKitGas { get; set; }

        [Display(Name = "Veículo alienado ou financiado?")]
        [Required(ErrorMessage = "Preencha o Campo Veículo alienado ou financiado?")]
        public bool FlagAlienado { get; set; }

        [Display(Name = "O veículo segurado possui dispositivo anti-furto, rastreador, bloqueador ou localizador instalado e ativado?")]
        [Required(ErrorMessage = "Preencha o Campo O veículo segurado possui dispositivo anti-furto, rastreador, bloqueador ou localizador instalado e ativado?")]
        public bool FlagAntiFurto { get; set; }

        [Display(Name = "Existe garagem ou estacionamento fechado para o veículo?")]
        [Required(ErrorMessage = "Preencha o Campo Existe garagem ou estacionamento fechado para o veículo?")]
        public bool FlagGararem { get; set; }

        [Display(Name = "Na residência?")]
        public string GararemResidencia { get; set; }

        [Display(Name = "No trabalho?")]
        public string GararemTrabalho { get; set; }

        [Display(Name = "No colégio/faculdade/pós-graduação?")]
        public string GararemFaculdade { get; set; }

        [Display(Name = "Propriedade do Rastreador?")]
        public string PropriedadeRastreador { get; set; }

        [Display(Name = "Qual a distância entre a residência do Principal Condutor até seu local de trabalho?")]
        public string DistanciaResidenciaTrabalho { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Rastreadores / Localizadores")]
        public IEnumerable<SelectListItem> Rastreadores { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Dispositivo Anti-Furto Comum")]
        public IEnumerable<SelectListItem> DispositivosFurtos { get; set; }

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