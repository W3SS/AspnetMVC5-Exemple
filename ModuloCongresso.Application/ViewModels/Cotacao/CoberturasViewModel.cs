using System.ComponentModel.DataAnnotations;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class CoberturasViewModel
    {
        [Key]
        public int CoberturaId { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public bool FlagObrigatorio { get; set; }

        public string Info { get; set; }
    }
}