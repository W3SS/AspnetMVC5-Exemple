using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        public ICollection<Modelo> Modelos { get; set; }
    }
}
