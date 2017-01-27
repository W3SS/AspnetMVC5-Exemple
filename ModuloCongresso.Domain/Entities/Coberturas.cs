using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Coberturas
    {
        public int CoberturaId { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public string Info { get; set; }

        public ICollection<CoberturasProduto> CoberturasProduto { get; set; }

        public ICollection<CoberturasItem> CoberturasItems { get; set; }
    }
}