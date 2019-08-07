using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Estudiantes
    {

        public Estudiantes()
        {
            EstudianteCursos = new List<EstudianteCurso>();

            EstudianteParientes = new List<EstudiantePariente>();
        }

        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Enfermedad { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }


        //Relacion
        public virtual List<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual List<EstudiantePariente> EstudianteParientes { get; set; }

    }
}
