using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class EstudiantePariente
    {

        public int IdEstudiante { get; set; }

        public String IdPariente { get; set; }

        [ForeignKey("IdEstudiante")]
        public virtual Estudiantes Estudiantes { get; set; }
        [ForeignKey("IdParientes")]
        public virtual Parientes Parientes { get; set; }

        public String TipoRelacion { get; set; }
    }
}
