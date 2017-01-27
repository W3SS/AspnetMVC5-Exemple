using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class TipoSeguro
    {
        public int TipoSeguroId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Cotacao> Cotacoes { get; set; }
    }
}