using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Models;
using VenturaHR.Domain.Repositories;
using VenturaHR.Domain.Services;

namespace VenturaHR.Application.Services
{
    public class StatsService : IStatsService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IVagaRepository vagaRepository;
        private readonly IRespostaRepository respostaRepository;
        private readonly IVagaCriterioRepository vagaCriterioRepository;

        public StatsService(IUsuarioRepository usuarioRepository,
                            IVagaRepository vagaRepository,
                            IRespostaRepository respostaRepository,
                            IVagaCriterioRepository vagaCriterioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.vagaRepository = vagaRepository;
            this.respostaRepository = respostaRepository;
            this.vagaCriterioRepository = vagaCriterioRepository;
        }
        public StatsResponse GetMonthlyStats()
        {
            var model = new StatsResponse
            {
                TotalRegisteredUsers = usuarioRepository.GetAll().Count(),
                TotalJobs = vagaRepository.GetAll().Count(),
                TotalJobApplicants = respostaRepository.GetAll().Count(),
                TotalJobCriterias = vagaCriterioRepository.GetAll().Count(),
            };

            return model;
        }
    }
}
