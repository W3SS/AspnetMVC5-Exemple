using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class TipoCalculo
    {
        public int TipoCalculoId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Cotacao> Cotacoes { get; set; }
    }
}