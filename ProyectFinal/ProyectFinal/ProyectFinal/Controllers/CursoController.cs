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
    public class CursoController : ControllerBase
    {

        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _cursoService.GetAll());
                
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _cursoService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Cursos model)
        {
            return Ok(
                _cursoService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Cursos model)
        {
            return Ok(
                _cursoService.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(
                _cursoService.Delete(id));
            

        }
    }
}
