using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {
            PerfilId = int.Parse(GeneratorNumber());
        }

        [Key]
        public int PerfilId { get; set; }

        [ScaffoldColumn(false)]
        public int CotacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Estado Civil")]
        public int EstadoCivilId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Tipo de Residencia")]
        public int TipoResidenciaId { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Preencha o Campo CPF do Principal Condutor")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo {0} caracteres")]
        public string CpfPrincipalCondutor { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha o Campo Nome do Principal Condutor")]
        public string NomePrincipalCondutor { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Preencha o Campo Data de Nascimento do Principal Condutor")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        public DateTime DataNascPrincipalCondutor { get; set; }

        [Display(Name = "O Principal Condutor reside com pessoa(s) menor(es) de 26 anos que possa(m) utilizar o veículo segurado?")]
        [Required(ErrorMessage = "Preencha o Campo O Principal Condutor reside com pessoa(s) menor(es) de 26 anos que possa(m) utilizar o veículo segurado?")]
        public bool FlagResideMenorIdade { get; set; }

        [Display(Name = "Segurado é o principal condutor?")]
        [Required(ErrorMessage = "Preencha o Campo Segurado é o principal condutor?")]
        public bool FlagSegPrincipalCondutor { get; set; }

        [Display(Name = "Você possui pontos na habilitação?")]
        [Required(ErrorMessage = "Preencha o Campo Você possui pontos na habilitação?")]
        public bool FlagPontosCarteira { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Sexo do Principal Condutor")]
        public int SexoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Tempo de Habilitação do Principal Condutor?")]
        public int TempoHabilitacaoId { get; set; }

        [Display(Name = "Quantidade de veículos na Residência?")]
        [Required(ErrorMessage = "Preencha o Campo Quantidade de veículos na Residência?")]
        public int QuantidadeVeicResidencia { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Distância até o Trabalho?")]
        public int DistanciaTrabalhoId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Sexo")]
        public IEnumerable<SelectListItem> Sexo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Qual a distância entre a residência do Principal Condutor até seu local de trabalho?")]
        public IEnumerable<SelectListItem> DistanciaTrabalho { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Tempo de Habilitação?")]
        public IEnumerable<SelectListItem> TempoHabilitacao { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Estado civil?")]
        public IEnumerable<SelectListItem> EstadoCivil { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Tipo de residência?")]
        public IEnumerable<SelectListItem> TipoResidencia { get; set; }

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