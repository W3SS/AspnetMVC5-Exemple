using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class PaisResidencia
    {
        public int PaisResidenciaID { get; set; }

        public string Nome { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
