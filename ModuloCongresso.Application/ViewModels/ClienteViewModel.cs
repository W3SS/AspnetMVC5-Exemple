using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<EnderecoViewModel>();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public int CotacaoId { get; set; }

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

        [Required(ErrorMessage = "Preencha o Campo Telefone")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Preencha o Campo RG")]
        [MaxLength(7, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(7, ErrorMessage = "Mínimo {0} caracteres")]
        public string RG { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        public ICollection<EnderecoViewModel> Enderecos { get; set; }

        public virtual ProfissaoViewModel Profissao { get; set; }

        public virtual PaisResidenciaViewModel PaisResidencia { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Profissao")]
        public int ProfissaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Pais de Residência")]
        public int PaisResidenciaId { get; set; }
    }
}
