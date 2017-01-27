namespace ModuloCongresso.Domain.Entities
{
    public class CoberturasProduto
    {
        public int CoberturaProdutoId { get; set; }

        public int CoberturaId { get; set; }

        public int ProdutoId { get; set; }

        public bool FlagObrigatorio { get; set; }

        public bool FlagBasica { get; set; }

        public float ValorMaximo { get; set; }

        public float ValorMinimo { get; set; }

        public double Taxa { get; set; }

        public double Franquia { get; set; }

        public virtual Produto Produtos { get; set; }

        public virtual Coberturas Coberturas { get; set; }
    }
}