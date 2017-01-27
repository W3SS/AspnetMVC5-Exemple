using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Descricao { get; set; }

        public ICollection<CoberturasProduto> CoberturasProduto { get; set; }
    }
}
