using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class TempoHabilitacao
    {
        public int TempoHabilitacaoId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Perfil> Perfis { get; set; }
    }
}