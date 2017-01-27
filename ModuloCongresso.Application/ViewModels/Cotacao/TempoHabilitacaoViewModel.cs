using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class TempoHabilitacaoViewModel
    {
        [Key]
        public int TempoHabilitacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Descricao")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }
    }
}