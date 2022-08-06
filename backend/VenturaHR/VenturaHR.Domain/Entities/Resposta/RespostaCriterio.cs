using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Resposta
{
    public class RespostaCriterio : IEntity<int>
    {
        public int Id { get; set; }

        public int Resposta { get; set; }       
    }
}
