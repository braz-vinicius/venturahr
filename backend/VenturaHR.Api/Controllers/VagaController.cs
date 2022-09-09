using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VenturaHR.Application.Authorization;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Services;

namespace VenturaHR.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        private readonly IVagaService vagaService;

        public VagaController(IVagaService vagaService)
        {
            this.vagaService = vagaService;
        }

        [HttpGet]
        public IEnumerable<Vaga> Get()
        {
            return vagaService.RetrieveAllVagas();
        }

        [HttpGet("{id}")]
        public Vaga Get(int id)
        {
            return vagaService.GetVaga(id);
        }

        [HttpPost]
        public void Post([FromBody] Vaga value)
        {
            vagaService.CreateVaga(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vaga value)
        {
            vagaService.UpdateVaga(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            vagaService.DeleteVaga(id);
        }
    }
}
