using Model;
using NUnit.Framework;
using Service;
using System.Linq;

namespace Tests
{

    [TestFixture]
    public class ProfesoresServiceTests
    {
        private ProfesoresService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ProfesoresService();
        }


        [Test]
        public void EsValido_ProfesoresConNombreVacioInvalido()
        {


            var profesores = new Profesores() { Id = "A456", Nombre = string.Empty, Telefono = "6565" };


            var result = _service.Esvalido(profesores);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }


        [Test]
        public void IsValido_ElTelefonoTieneMenorDigitosAlCorrespodientesEsInvalido()
        {

            var profesores = new Profesores() { Id = "A456", Nombre = "MIguel", Telefono = "6565"};


            var result = _service.Esvalido(profesores);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }


    


        [Test]
        public void IsValido_ElIdTieneNoDigitosAlCorrespodientesEsInvalido()
        {

            var profesores = new Profesores() { Id = "A456", Nombre = "MIguel", Telefono = "6565" };


            var result = _service.Esvalido(profesores);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }
    

        [Test]
        public void EsValido_PersonaValidaRetornaVerdaderoYNoHayErrores()
        {

            var profesores = new Profesores() { Id = "A4556" , Nombre = "MIguel", Telefono = "8099182010"};


            var result = _service.Esvalido(profesores);

            Assert.IsTrue(result);
            Assert.IsFalse(_service.Errores.Any());
        }



    }
}