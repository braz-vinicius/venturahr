using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Repositories;
using VenturaHR.Infrastructure.Data.Providers;

namespace VenturaHR.Infrastructure.Data.Repositories
{
    public class RespostaRepository : SqlRepository<Resposta, int>, IRespostaRepository
    {
        public RespostaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
