using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class TipoResidenciaViewModel
    {
        [Key]
        public int TipoResidenciaId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Descricao")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }
    }
}