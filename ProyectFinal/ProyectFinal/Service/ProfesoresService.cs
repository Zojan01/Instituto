using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IProfesoresService
    {
        IEnumerable<Profesores> GetAll();
        Profesores Get(String id); 
        bool Add(Profesores model);
        bool Update(Profesores model);
        bool Delete(String id);

    }   
    public class ProfesoresService : IProfesoresService
    {
        private readonly ProjectDbContext _projectDbContext;

        public ProfesoresService(ProjectDbContext projectDbContex)
        {
            _projectDbContext = projectDbContex;
        }

        public ProfesoresService()
        {
        }

        public List<String> Errores { get; private set; }
        public bool Esvalido(Profesores model)
        {
            Errores = new List<string>();
            var valido = true;

            if (string.IsNullOrWhiteSpace(model.Nombre))
            {
                Errores.Add("El nombre del profesor es requerido");
                valido = false;
            }

            if (model.Telefono.Length != 10)
            {
                Errores.Add("El telefono ingresado le faltan digitos");
                valido = false;
            }
            if (model.Id.Length != 5)
            {
                Errores.Add("El id de los profesores solo se limita a  5 digitos, verifique la cantidad de digitos ingresado");
                valido = false;
            }

            return valido;
        }


        public IEnumerable<Profesores> GetAll()
        {

            var result = new List<Profesores>();

            try
            {
                result = _projectDbContext.Profesores.ToList();
            }
            catch (System.Exception)
            {
              
            }
            return result;
        }


        public Profesores Get(String  id)
        {

            var result = new Profesores();

            try
            {
                result = _projectDbContext.Profesores.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }


        public bool Add(Profesores model)
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

        public bool Update(Profesores model)
        {
            try
            {
                var originalModel = _projectDbContext.Profesores.Single(x =>
                x.Id == model.Id);

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.Materia = model.Materia;
                originalModel.Direccion = model.Direccion;
                originalModel.Telefono = model.Telefono;


                _projectDbContext.Update(originalModel);
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }


        public bool Delete(String id)
        {
            try
            {
                _projectDbContext.Entry(new Profesores { Id = id }).State = EntityState.Deleted;
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Profesores> GetAll(Profesores model)
        {
            throw new NotImplementedException();
        }

        public Profesores Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
