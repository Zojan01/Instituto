using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Cursos
    {
        public Cursos()
        {
            EstudianteCursos = new List<EstudianteCurso>();

            ProfesorCurso = new List<ProfesorCurso>();
        }


        [Key]
        public int Id { get; set; }
        public String CursoNombre { get; set; }
        public String CursoGrado { get; set; }


        //Relacion
        public virtual List<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual List<ProfesorCurso> ProfesorCurso { get; set; }
    }
}
