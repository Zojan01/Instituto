using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class ProjectDbContext : DbContext
    {

        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Parientes> Parientes { get; set; }


        //relaciones
        public DbSet<ProfesorCurso> ProfesorCursos { get; set; }
        public DbSet<EstudianteCurso> EstudianteCursos { get; set; }
        public DbSet<EstudiantePariente> EstudianteParientes { get; set; }


        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProfesorCurso>().HasKey(x => new { x.IdCurso, x.IdProfesor });
            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.IdCurso, x.IdEstudiante });
            modelBuilder.Entity<EstudiantePariente>().HasKey(x => new { x.IdEstudiante, x.IdPariente });
        }

    }
}
