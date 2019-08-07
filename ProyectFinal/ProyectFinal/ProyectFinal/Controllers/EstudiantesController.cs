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
    public class EstudiantesController : ControllerBase
    {

        private readonly IEstudiantesService _estudiantesService;

        public EstudiantesController(IEstudiantesService estudiantesService)
        {
            _estudiantesService = estudiantesService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _estudiantesService.GetAll());
                
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _estudiantesService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Estudiantes model)
        {
            return Ok(
                _estudiantesService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Estudiantes model)
        {
            return Ok(
                _estudiantesService.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(
                _estudiantesService.Delete(id));

        }
    }
}
