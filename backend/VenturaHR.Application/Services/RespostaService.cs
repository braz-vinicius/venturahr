using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Repositories;

namespace VenturaHR.Domain.Services
{
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepository respostaRepository;
        private readonly IRespostaCriterioRepository criterioRepository;

        public RespostaService(IRespostaRepository respostaRepository, IRespostaCriterioRepository criterioRepository)
        {
            this.respostaRepository = respostaRepository;
            this.criterioRepository = criterioRepository;
        }

        public void CreateResposta(Resposta resposta)
        {
            resposta.DataResposta = DateTime.UtcNow;

            respostaRepository.Add(resposta);

        }

        public List<Resposta> RetrieveAllRespostas()
        {
            return respostaRepository.GetAll().OrderByDescending(x => x.DataResposta).ToList();
        }

        public void DeleteResposta(int id)
        {
            respostaRepository.DeleteById(id);
        }

        public Resposta GetResposta(int id)
        {
            return respostaRepository.Get(x => x.Id == id);
        }

        public void UpdateResposta(int id, Resposta value)
        {
            respostaRepository.Update(value);
        }

        public IEnumerable<RespostaCriterio> GetCriteriosByRespostaId(int id)
        {
            var criterios = criterioRepository.FindWhere(x => x.RespostaId == id);

            return criterios;
        }

        public RespostaCriterio GetRespostaCriterio(int id)
        {
            var criterio = criterioRepository.Get(x => x.Id == id);

            return criterio;
        }

        public void CreateRespostaCriterio(RespostaCriterio value)
        {
            criterioRepository.CreateOrUpdate(value);
        }

        public void UpdateRespostaCriterio(int id, RespostaCriterio value)
        {
            criterioRepository.Update(value);
        }

        public void DeleteRespostaCriterio(int id)
        {
            criterioRepository.DeleteById(id);
        }
    }
}
