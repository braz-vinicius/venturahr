using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Repositories;

namespace VenturaHR.Domain.Services
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository _repository;

        public VagaService(IVagaRepository repository)
        {
            _repository = repository;
        }

        public void CreateVaga(Vaga vaga)
        {
            vaga.DataCriacao = DateTime.UtcNow;

            _repository.Add(vaga);

        }

        public List<Vaga> RetrieveAllVagas()
        {
            return _repository.GetAll().OrderByDescending(x => x.DataCriacao).ToList();
        }

        public void DeleteVaga(int id)
        {
            _repository.DeleteById(id);
        }

        public Vaga GetVaga(int id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}
