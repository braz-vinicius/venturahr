using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VenturaHR.Domain.Models;
using VenturaHR.Domain.Services;

namespace VenturaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService statsService;

        public StatsController(IStatsService statsService)
        {
            this.statsService = statsService;
        }

        [HttpGet]
        public StatsResponse Get()
        {
            return statsService.GetMonthlyStats();
        }
    }
}
