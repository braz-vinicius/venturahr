using System;
using System.Collections.Generic;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Resposta
{
    public class Resposta : IEntity<int>
    {
        public int Id { get; set; }

        public virtual Candidato Candidato { get; set; }

        public int CandidatoId { get; set; }

        public DateTime DataResposta { get; set; }
        
        public decimal Indice { get; set; }

        public virtual ICollection<RespostaCriterio> Criterios { get; set; }
    }
}
