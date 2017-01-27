using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Imposto
    {
        public int ImpostoId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Item> Itens { get; set; }
    }
}