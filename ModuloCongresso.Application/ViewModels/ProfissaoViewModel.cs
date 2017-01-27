using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCongresso.Application.ViewModels
{
    public class ProfissaoViewModel
    {
        [Key]
        public int ProfissaoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
    }
}
