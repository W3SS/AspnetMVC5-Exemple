﻿using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class TipoCalculoViewModel
    {
        [Key]
        public int TipoCalculoId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }
    }
}