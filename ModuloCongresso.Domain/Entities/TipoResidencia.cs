﻿using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class TipoResidencia
    {
        public int TipoResidenciaId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Perfil> Perfis { get; set; }
    }
}