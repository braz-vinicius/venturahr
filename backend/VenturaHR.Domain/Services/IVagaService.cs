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
    }
}