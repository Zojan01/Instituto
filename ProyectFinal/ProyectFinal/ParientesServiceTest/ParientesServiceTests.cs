using Model;
using NUnit.Framework;
using Service;
using System;

namespace ParientesServiceTest
{
    public class ParientesServiceTests
    {

        [Test]
        public void EstuadianteValido()
        {

            var service = new EstudiantesService();
            var estudiante = new Estudiantes() { Nombre = string.Empty };


            var result = service.Esvalido(estudiante);

            Assert.IsFalse(result);
        }

        [Test]
        public void EdadEstudianteValidad()
        {
            var service = new EstudiantesService();
            var estudiante = new Estudiantes() { Nombre = "235234", Apellido = "asdfasdfasd", Edad = 12 };
            var result = service.Esvalido(estudiante);

            Assert.IsFalse(result);

        }


    }
}
     