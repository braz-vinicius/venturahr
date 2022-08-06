using System;
using System.Collections.Generic;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Resposta
{
    public class Resposta : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime RespostaData { get; set; }
        
        public Decimal Indice { get; set; }
    }
}
