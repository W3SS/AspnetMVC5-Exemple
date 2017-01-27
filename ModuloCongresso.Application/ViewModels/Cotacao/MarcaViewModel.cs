using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class MarcaViewModel
    {
        [Key]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public string Imagem { get; set; }
    }
}
