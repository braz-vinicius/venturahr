﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VenturaHR.Application.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VenturaHR.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        // GET: api/<VagaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VagaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VagaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VagaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VagaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}