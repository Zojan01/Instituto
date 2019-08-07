using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class EstudianteCurso
    {
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }

        [ForeignKey("IdEstudiante")]
        public virtual Estudiantes Estudiante { get; set; }
        [ForeignKey("IdCurso")]
        public virtual Cursos Curso { get; set; }



    }
}
