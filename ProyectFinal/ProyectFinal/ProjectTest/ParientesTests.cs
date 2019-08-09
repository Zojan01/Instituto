using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace ProjectTest
{
    [TestClass]
    public class ParientesTests
    {
        [TestMethod]
        public void EstudianteValido()
        {

            var service = new EstudiantesService();
            var estudiante = new Estudiantes() { Nombre = string.Empty };
            

            var result = service.Esvalido(estudiante)

        }
    }
}
