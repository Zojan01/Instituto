using Model;
using NUnit.Framework;
using Service;
using System.Linq;

namespace Tests
{

    [TestFixture]
    public class ParientesServiceTests
    {
        private ParientesService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ParientesService();
        }

        [Test]
        public void EsValido_ParientesConNombreVacioInvalido()
        {


            var parientes = new Parientes() { Nombre = string.Empty, Apellido = "Padrino", Direccion = "Al lado de tu casa", Cedula = "00136035473" };


            var result = _service.Esvalido(parientes);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }


        [Test]
        public void EsValido_ParientesConNumeroDeDigitosDeCedulaIncorrectoInvalido()
        {
            var parientes = new Parientes() { Nombre = "Alex", Apellido = "Padrino", Direccion = "Al lado de tu casa", Cedula = "464" };


            var result = _service.Esvalido(parientes);

            Assert.IsFalse(result);
            Assert.IsTrue(_service.Errores.Any());
        }


        [Test]
        public void EsValido_ParienteValid0RetornaVerdaderoYNoHayErrores()
        {

            var parientes = new Parientes() { Nombre = "Miguel", Apellido = "Nuñez Giron", Direccion = "Ninguna", Cedula = "00136038483"};


            var result = _service.Esvalido(parientes);

            Assert.IsTrue(result);
            Assert.IsFalse(_service.Errores.Any());
        }


    }
}