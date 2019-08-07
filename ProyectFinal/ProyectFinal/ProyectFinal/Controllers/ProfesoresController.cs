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
    public class ProfesoresController : ControllerBase
    {

        private readonly IProfesoresService _profesoresService;

        public ProfesoresController(IProfesoresService profesoresService)
        {
            _profesoresService = profesoresService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _profesoresService.GetAll()
                );
                
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(String id)
        {
            return Ok(
                 _profesoresService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Profesores model)
        {
            return Ok(
                _profesoresService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Profesores model)
        {
            return Ok(
                _profesoresService.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {

            return Ok(
                _profesoresService.Delete(id));

        }
    }
}
