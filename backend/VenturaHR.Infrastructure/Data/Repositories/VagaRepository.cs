using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Repositories;
using VenturaHR.Infrastructure.Data.Providers;

namespace VenturaHR.Infrastructure.Data.Repositories
{
    public class VagaRepository : SqlRepository<Vaga, int>, IVagaRepository
    {
        public VagaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
