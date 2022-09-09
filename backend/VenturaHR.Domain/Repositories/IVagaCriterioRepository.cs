using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Repositories
{
    public interface IVagaCriterioRepository : IRepository<VagaCriterio, int>
    {
    }
}
