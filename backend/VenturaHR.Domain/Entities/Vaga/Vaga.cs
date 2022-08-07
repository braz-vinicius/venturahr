using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Vaga
{
    public class Vaga : IEntity<int>
    {
        public int Id { get; set; }

        public virtual Empresa Empresa { get; set; }

        public int EmpresaId { get; set; }

        [MaxLength(45)]
        public string Cargo { get; set; }
        
        [MaxLength(45)]
        public string Cidade { get; set; }

        [MaxLength(45)]
        public string FormaContratacao { get; set; }

        public DateTime DataExpiracao { get; set; }

        public virtual ICollection<VagaCriterio> Criterios { get; set; }

        public virtual ICollection<Resposta.Resposta> Respostas { get; set; }
    }
}
