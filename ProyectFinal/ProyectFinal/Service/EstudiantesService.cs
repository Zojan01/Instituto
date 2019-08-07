﻿using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IEstudiantesService
    {
        IEnumerable<Estudiantes> GetAll();
        Estudiantes Get(int id); 
        bool Add(Estudiantes model);
        bool Update(Estudiantes model);
        bool Delete(int id);

    }   
    public class EstudiantesService : IEstudiantesService
    {
        private readonly ProjectDbContext _projectDbContext;

        public EstudiantesService(ProjectDbContext projectDbContex)
        {
            _projectDbContext = projectDbContex;
        }


      
        public IEnumerable<Estudiantes> GetAll()
        {

            var result = new List<Estudiantes>();

            try
            {
                result = _projectDbContext.Estudiantes.ToList();
            }
            catch (System.Exception)
            {
              
            }
            return result;
        }


        public Estudiantes Get(int  id)
        {

            var result = new Estudiantes();

            try
            {
                result = _projectDbContext.Estudiantes.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }


        public bool Add(Estudiantes model)
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

        public bool Update(Estudiantes model)
        {
            try
            {
                var originalModel = _projectDbContext.Estudiantes.Single(x =>
                x.Id == model.Id);

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.Edad = model.Edad;
                originalModel.Sexo = model.Sexo;
                originalModel.Enfermedad = model.Enfermedad;


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
                _projectDbContext.Entry(new Estudiantes { Id = id }).State = EntityState.Deleted;
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

       
    }
}