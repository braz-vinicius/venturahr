using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Repositories;
using VenturaHR.Infrastructure.Data.Providers;

namespace VenturaHR.Infrastructure.Data.Repositories
{
    public class VagaCriterioRepository : SqlRepository<VagaCriterio, int>, IVagaCriterioRepository
    {
        public VagaCriterioRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
