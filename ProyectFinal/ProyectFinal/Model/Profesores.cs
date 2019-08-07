using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Profesores
    {
        public Profesores()
        {
            ProfesorCurso = new List<ProfesorCurso>();

        }


        [Key]
        public String Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Materia { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        //Relacion

        public virtual List<ProfesorCurso> ProfesorCurso { get; set; }



    }
}
