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

        /// <summary>
        /// Metodo get para optener todos los cursos que se encuentra en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _cursosService.Get(id));
        }


        /// <summary>
        /// Este metodo nos servira  para agregar el curso.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Cursos model)
        {
            return Ok(
                _cursosService.Add(model));
        }
        /// <summary>
        /// Me todo para actualizar , se pasa el objeto curso y desde el id del objeto se procedera a hacer las modifciaciones.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Cursos model)
        {
            return Ok(
                _cursosService.Add(model));
        }
        /// <summary>
        /// Metodo para elimar curos 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(
                _cursosService.Delete(id));

        }
    }
}
