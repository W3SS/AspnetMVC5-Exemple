using System;
using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
        }

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
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
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

        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }
    }
}
