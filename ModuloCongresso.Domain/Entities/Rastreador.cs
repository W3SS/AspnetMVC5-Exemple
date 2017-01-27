using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Rastreador
    {
        public int RastreadorId { get; set; }

        public string Nome { get; set; }

        public ICollection<Questionario> Questionarios { get; set; }
    }
}