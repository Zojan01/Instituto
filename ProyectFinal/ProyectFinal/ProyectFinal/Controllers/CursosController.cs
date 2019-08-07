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
    public class CursosController : ControllerBase
    {

        private readonly ICursosService _cursosService;

        public CursosController(ICursosService cursosService)
        {
            _cursosService = cursosService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _cursosService.GetAll()
                );
                
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _cursosService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Cursos model)
        {
            return Ok(
                _cursosService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Cursos model)
        {
            return Ok(
                _cursosService.Add(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(
                _cursosService.Delete(id));

        }
    }
}
