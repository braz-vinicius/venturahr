using System.Collections.Generic;
using VenturaHR.Domain.Entities.Vaga;

namespace VenturaHR.Domain.Services
{
    public interface IVagaService
    {
        void CreateVaga(Vaga vaga);
        void DeleteVaga(int id);
        Vaga GetVaga(int id);
        List<Vaga> RetrieveAllVagas();
        void UpdateVaga(int id, Vaga value);
        IEnumerable<VagaCriterio> GetVagaCriterios(int vagaId);
        VagaCriterio GetVagaCriterio(int vagaId, int id);
        void PostVagaCriterio(VagaCriterio value);
        void DeleteVagaCriterio(int id);       
    }
}