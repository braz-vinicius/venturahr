using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Vaga
{
    public class VagaCriterio : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(45)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required]
        public int Perfil { get; set; }

        [Required]
        public int Peso { get; set; }

        public virtual Vaga Vaga { get; set; }

        [Required]
        public int VagaId { get; set; }

        public virtual ICollection<RespostaCriterio> RespostaCriterios { get; set; }
    }
}
