using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ProyectFinal.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ParientesController : ControllerBase
    {

        private readonly IParientesService _parientesService;

        public ParientesController(IParientesService parientesService)
        {
            _parientesService = parientesService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _parientesService.GetAll());       
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(String id)
        {
            return Ok(
                _parientesService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Parientes model)
        {
            return Ok(
                _parientesService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Parientes model)
        {
            return Ok(
                _parientesService.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {

            return Ok(
                _parientesService.Delete(id));

        }
    }
}
