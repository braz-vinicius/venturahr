using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Repositories;
using VenturaHR.Infrastructure.Data.Providers;

namespace VenturaHR.Infrastructure.Data.Repositories
{
    public class RespostaCriterioRepository : SqlRepository<RespostaCriterio, int>, IRespostaCriterioRepository
    {
        public RespostaCriterioRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
