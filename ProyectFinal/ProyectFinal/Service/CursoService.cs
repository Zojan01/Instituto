﻿using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface ICursoService
    {
        IEnumerable<Cursos> GetAll();
        Cursos Get(int id); 
        bool Add(Cursos model);
        bool Update(Cursos model);
        bool Delete(int id);

    }   
    public class CursoService : ICursoService
    {
        private readonly ProjectDbContext _projectDbContext;

        public CursoService(ProjectDbContext projectDbContex)
        {
            _projectDbContext = projectDbContex;
        }


      
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


        public Cursos Get(int  id)
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

                originalModel.CursoNombre= model.CursoNombre;
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
                _projectDbContext.Entry(new Cursos { Id = id }).State = EntityState.Deleted;
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