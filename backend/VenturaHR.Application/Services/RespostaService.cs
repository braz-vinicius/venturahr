using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Repositories;

namespace VenturaHR.Domain.Services
{
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepository _repository;

        public RespostaService(IRespostaRepository repository)
        {
            _repository = repository;
        }

        public void CreateResposta(Resposta resposta)
        {
            resposta.DataResposta = DateTime.UtcNow;

            _repository.Add(resposta);

        }

        public List<Resposta> RetrieveAllRespostas()
        {
            return _repository.GetAll().OrderByDescending(x => x.DataResposta).ToList();
        }

        public void DeleteResposta(int id)
        {
            _repository.DeleteById(id);
        }

        public Resposta GetResposta(int id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}
