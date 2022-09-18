using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Repositories;

namespace VenturaHR.Domain.Services
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository vagaRepository;
        private readonly IVagaCriterioRepository criterioRepository;

        public VagaService(IVagaRepository vagaRepository, IVagaCriterioRepository criterioRepository)
        {
            this.vagaRepository = vagaRepository;
            this.criterioRepository = criterioRepository;
        }

        public void CreateVaga(Vaga vaga)
        {
            vaga.DataCriacao = DateTime.UtcNow;
            vaga.DataExpiracao = DateTime.UtcNow.AddDays(30);
            vaga.Perfil = CalculateVagaPerfil(vaga);
            vagaRepository.Add(vaga);

        }

        private decimal CalculateVagaPerfil(Vaga vaga)
        {
            decimal notaPerfil = Decimal.Divide( vaga.Criterios.Sum(x => x.Perfil * x.Peso) , vaga.Criterios.Sum(x => x.Peso));

            return notaPerfil;
        }

        public List<Vaga> RetrieveAllVagas()
        {
            return vagaRepository.GetAll("Empresa", "Criterios", "Respostas", "Respostas.Candidato").OrderByDescending(x => x.DataCriacao).ToList();
        }

        public void DeleteVaga(int id)
        {
            vagaRepository.DeleteById(id);
        }

        public Vaga GetVaga(int id)
        {
            return vagaRepository.Get(x => x.Id == id, "Empresa", "Criterios");
        }

        public void UpdateVaga(int id, Vaga value)
        {
            vagaRepository.Update(value);
        }

        public IEnumerable<VagaCriterio> GetVagaCriterios(int vagaId)
        {
            return criterioRepository.FindWhere(x => x.VagaId == vagaId).ToList();
        }

        public VagaCriterio GetVagaCriterio(int vagaId, int id)
        {
            return criterioRepository.Get(x => x.Id == id);
        }

        public void PostVagaCriterio(VagaCriterio value)
        {
            criterioRepository.CreateOrUpdate(value);
        }

        public void DeleteVagaCriterio(int id)
        {
            criterioRepository.DeleteById(id);
        }
    }
}
