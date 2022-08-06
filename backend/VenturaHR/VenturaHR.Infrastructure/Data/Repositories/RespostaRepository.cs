using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Infrastructure.Data.Providers;

namespace VenturaHR.Infrastructure.Data.Repositories
{
    public class RespostaRepository : SqlRepository<Resposta, int>
    {
        public RespostaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
