using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface ICursosService
    {
        IEnumerable<Cursos> GetAll();
        Cursos Get(int id); 
        bool Add(Cursos model);
        bool Update(Cursos model);
        bool Delete(int id);

    }   
    public class CursosService : ICursosService
    {
        private readonly ProjectDbContext _projectDbContext;

        public CursosService(ProjectDbContext projectDbContex)
        {
            _projectDbContext = projectDbContex;
        }

        public CursosService()
        {
        }

        public List<String> Errores { get; private set; }
        public bool Esvalido(Cursos model)
        {
            Errores = new List<string>();
            var valido = true;

            if (string.IsNullOrWhiteSpace(model.CursoNombre))
            {
                Errores.Add("El  nombre del curso es requerido");
                valido = false;
            }

            if (model.CursoGrado != "1" || model.CursoGrado != "2" || model.CursoGrado != "3" || model.CursoGrado != "4" || model.CursoGrado != "5")
            {
                Errores.Add("El Grado del curso no se encuentra entre los cursos validos");
                valido = false;
            }
          

            return valido;
        }


        //Trabajando con el  Crud de la entidad Cursos
        public IEnumerable<Cursos> GetAll()
        {

            var result = new List<Cursos>();

            try
            {
                result = _projectDbContext.Cursos.ToList();
            }
            catch (System.Exception)
            {
              
            }
            return result;
        }


        public Cursos Get(int id)
        {

            var result = new Cursos();

            try
            {
                result = _projectDbContext.Cursos.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }


        public bool Add(Cursos model)
        {
            try
            {
                _projectDbContext.Add(model);
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;            
        }

        public bool Update(Cursos model)
        {
            try
            {
                var originalModel = _projectDbContext.Cursos.Single(x =>
                x.Id == model.Id);

                originalModel.CursoNombre = model.CursoNombre;
                originalModel.CursoGrado = model.CursoGrado;



                _projectDbContext.Update(originalModel);
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }


        public bool Delete(int id)
        {
            try
            {
                _projectDbContext.Entry(new Cursos {Id = id }).State = EntityState.Deleted; ; 
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Cursos> GetAll(Cursos model)
        {
            throw new NotImplementedException();
        }
    }
}
