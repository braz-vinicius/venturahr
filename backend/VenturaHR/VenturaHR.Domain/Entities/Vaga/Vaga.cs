using System;
using System.Collections.Generic;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Vaga
{
    public class Vaga : IEntity<int>
    {
        public int Id { get; set; }

        public string Cargo { get; set; }

        public string Cidade { get; set; }

        public string FormaContratacao { get; set; }

        public DateTime DataExpiracao { get; set; }

        ICollection<VagaCriterio> Criterios { get; set; }
    }
}
