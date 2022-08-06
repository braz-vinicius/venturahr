using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Vaga
{
    public class VagaCriterio : IEntity<int>
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Perfil { get; set; }

        public int Peso { get; set; }
    }
}
