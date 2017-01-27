using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class AntiFurto
    {
        public int AntiFurtoId { get; set; }

        public string Nome { get; set; }

        public ICollection<Questionario> Questionarios { get; set; }
    }
}