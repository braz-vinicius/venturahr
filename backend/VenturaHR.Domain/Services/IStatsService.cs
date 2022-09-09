using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Models;

namespace VenturaHR.Domain.Services
{
    public interface IStatsService
    {
        StatsResponse GetMonthlyStats();
    }
}
