using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ModuloCongresso.Application.ViewModels
{
    public class ClienteEnderecoViewModel
    {
        public ClienteEnderecoViewModel()
        {
            ClienteId = Guid.NewGuid();
            EnderecoId = Guid.NewGuid();
        }

        #region  Cliente
        [Key]
        public Guid ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public int CotacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Profissao")]
        public int ProfissaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Pais Residencia")]
        public int PaisResidenciaId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Campo SobreNome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Email")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-Mail válido")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o Campo CPF")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Display(Name = "Telefone/Celular")]
        [Required(ErrorMessage = "Preencha o Campo Telefone")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Preencha o Campo RG")]
        [MaxLength(7, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(7, ErrorMessage = "Mínimo {0} caracteres")]
        public string RG { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Inscrito { get; set; }

        [ScaffoldColumn(false)]
        public byte[] ImagePhoto { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Profissão")]
        public IEnumerable<SelectListItem> Profissoes { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Pais")]
        public IEnumerable<SelectListItem> Pais { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        #endregion

        #region Endereço
        [Key]
        public Guid EnderecoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Número")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Numero { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Bairro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o Campo CEP")]
        [MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Cidade")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Estado")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Estado { get; set; }

        #endregion
    }
}
