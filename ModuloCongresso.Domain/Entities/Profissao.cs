using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Profissao
    {
        public int ProfissaoID { get; set; }

        public string Nome { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
