using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Resposta
{
    public class RespostaCriterio : IEntity<int>
    {
        public int Id { get; set; }

        public int Perfil { get; set; }

        public VagaCriterio VagaCriterio { get; set; }

        public int VagaCriterioId { get; set; }

        public Resposta Resposta { get; set; }

        public int RespostaId { get; set; }
    }
}
