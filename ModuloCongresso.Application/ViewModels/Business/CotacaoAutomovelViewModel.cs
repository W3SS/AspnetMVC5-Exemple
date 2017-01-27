using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Infra.CrossCutting.MvcFilters;

namespace ModuloCongresso.Application.ViewModels.Business
{
    public class CotacaoAutomovelViewModel
    {
        public CotacaoAutomovelViewModel()
        {
            CotacaoId =  int.Parse(GeneratorNumber());
            ItemId = int.Parse(GeneratorNumber());
            ProdutoId = (int) Produtos.Automóvel;
            PerfilId = int.Parse(GeneratorNumber());
            QuestionarioId = int.Parse(GeneratorNumber());
        }

        #region Cotação Automóvel

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
        #endregion

        #region Cliente
        public ClienteEnderecoViewModel Cliente { get; set; }

        #endregion 

        #region Item

        [Key]
        public int ItemId { get; set; }

        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Uso")]
        public string Uso { get; set; }

        [Display(Name = "Isenção de Imposto?")]
        [Required(ErrorMessage = "Preencha o Campo Isenção de Imposto")]
        public string Isencao { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Modelo")]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Descricao")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Ano de Fabricação")]
        [Required(ErrorMessage = "Preencha o Campo Ano de Fabricação")]
        [MaxLength(4, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo {0} caracteres")]
        public string AnoFabricacao { get; set; }

        [Display(Name = "Ano do Modelo")]
        [Required(ErrorMessage = "Preencha o Campo Ano do Modelo")]
        [MaxLength(4, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo {0} caracteres")]
        public string AnoModelo { get; set; }

        [Display(Name = "Zero KM?")]
        [Required(ErrorMessage = "Preencha o Campo FlagZeroKm")]
        public bool FlagZeroKm { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Valor")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo {0} caracteres")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Marca")]
        public int MarcaId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Marca / Fabricante")]
        public IEnumerable<SelectListItem> Marcas { get; set; }

        public virtual ModeloViewModel Modelo { get; set; }

        public List<CoberturasViewModel> ListCoberturas { get; set; }

        #endregion

        #region Perfil

        [Key]
        public int PerfilId { get; set; }

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

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Preencha o Campo Sexo do Principal Condutor")]
        public string Sexo { get; set; }

        [Display(Name = "Tempo de Habilitação?")]
        [Required(ErrorMessage = "Preencha o Campo Tempo de Habilitação do Principal Condutor?")]
        public int TempoHabilitacao { get; set; }

        [Display(Name = "Quantidade de veículos na Residência?")]
        [Required(ErrorMessage = "Preencha o Campo Quantidade de veículos na Residência?")]
        public int QuantidadeVeicResidencia { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Estado civil?")]
        public IEnumerable<SelectListItem> EstadoCivil { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Tipo de residência?")]
        public IEnumerable<SelectListItem> TipoResidencia { get; set; }

        #endregion

        #region Questionario

        [Key]
        public int QuestionarioId { get; set; }

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

        #endregion

        #region Coberturas

        [ScaffoldColumn(false)]
        public IEnumerable<CoberturaItemViewModel> SelectedCoberturas { get; set; }

        #endregion

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

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}