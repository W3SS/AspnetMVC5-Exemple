﻿using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class DistanciaTrabalho
    {
        public int DistanciaTrabalhoId { get; set; }

        public string Descricao { get; set; }

        public ICollection<Perfil> Perfis { get; set; }
    }
}