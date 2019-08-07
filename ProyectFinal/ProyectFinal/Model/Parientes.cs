using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Parientes
    {
        public Parientes()
        {
            EstudianteParientes = new List<EstudiantePariente>();
        }


        [Key]
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        //Relacion
        public virtual List<EstudiantePariente> EstudianteParientes { get; set; }


    }
}
