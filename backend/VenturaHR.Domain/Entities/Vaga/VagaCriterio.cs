using System.ComponentModel.DataAnnotations;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Vaga
{
    public class VagaCriterio : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(45)]
        public string Descricao { get; set; }

        public int Perfil { get; set; }

        public int Peso { get; set; }

       // public virtual Vaga Vaga { get; set; }

        public int VagaId { get; set; }
    }
}
