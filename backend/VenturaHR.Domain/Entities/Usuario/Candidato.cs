using System.Collections.Generic;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Usuario
{
    public class Candidato : Usuario
    {
        public string CPF { get; set; }

        public virtual ICollection<Resposta.Resposta> Respostas { get; set; }
    }
}
