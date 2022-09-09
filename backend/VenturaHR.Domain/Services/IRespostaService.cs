using System.Collections.Generic;
using VenturaHR.Domain.Entities.Resposta;

namespace VenturaHR.Domain.Services
{
    public interface IRespostaService
    {
        void CreateResposta(Resposta resposta);
        void DeleteResposta(int id);
        Resposta GetResposta(int id);
        List<Resposta> RetrieveAllRespostas();
        void UpdateResposta(int id, Resposta value);
        IEnumerable<RespostaCriterio> GetCriteriosByRespostaId(int id);
        RespostaCriterio GetRespostaCriterio(int id);
        void CreateRespostaCriterio(RespostaCriterio value);
        void UpdateRespostaCriterio(int id, RespostaCriterio value);
        void DeleteRespostaCriterio(int id);
    }
}