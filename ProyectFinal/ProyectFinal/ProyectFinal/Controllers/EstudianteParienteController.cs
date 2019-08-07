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
    public class EstudianteParienteController : ControllerBase
    {

        private readonly IEstudianteParienteService _estudiantePariente;

        public EstudianteParienteController(IEstudianteParienteService estudiantePariente)
        {
            _estudiantePariente = estudiantePariente;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _estudiantePariente.GetAll());
                
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _estudiantePariente.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] EstudiantePariente model)
        {
            return Ok(
                _estudiantePariente.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] EstudiantePariente model)
        {
            return Ok(
                _estudiantePariente.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(
                _estudiantePariente.Delete(id));

        }
    }
}
