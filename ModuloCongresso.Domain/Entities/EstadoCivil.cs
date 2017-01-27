using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class EstadoCivil
    {
        public int EstadoCivilId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Perfil> Perfis { get; set; }
    }
}