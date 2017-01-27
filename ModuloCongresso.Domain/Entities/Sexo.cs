using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Sexo
    {
        public int SexoId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Perfil> Perfis { get; set; }
    }
}