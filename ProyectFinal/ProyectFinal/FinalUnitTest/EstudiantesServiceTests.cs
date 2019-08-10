using Model;
using NUnit.Framework;
using Service;
using System.Linq;

namespace Tests
{

    [TestFixture]
    public class EstudiantesServiceTests
    {
        private EstudiantesService _service;

        [SetUp]
        public void Setup()
        {
            _service = new EstudiantesService();
        }

        [Test]
        public void EsValido_EstudianteConNombreVacioInvalido()
        {
                
          
            var estudiante = new Estudiantes() { Nombre = string.Empty };


            var result = _service.Esvalido(estudiante);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }


        [Test]
        public void EsValido_PersonaConEdadIncorrectaEsInvalido()
        {

            var estudiante = new Estudiantes() { Nombre = string.Empty, Edad = 20 };


            var result = _service.Esvalido(estudiante);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }

        [Test]
        public void EsValido_PersonaConEdadMayorQue90EsInvalido()
        {
      
            var estudiante = new Estudiantes() { Nombre = string.Empty, Edad = 5 };


            var result = _service.Esvalido(estudiante);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }

        [Test]
        public void EsValido_PersonaValidaRetornaVerdaderoYNoHayErrores()
        {
            
            var estudiante = new Estudiantes() {Nombre = "Miguel", Apellido = "Nuñez Giron", Enfermedad = "Ninguna", Sexo = "M" , Edad = 20 };


            var result = _service.Esvalido(estudiante);

            Assert.IsTrue(result);
            Assert.IsFalse(_service.Errores.Any());
        }
        
    }
}