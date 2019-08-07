using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IParientesService
    {
        IEnumerable<Parientes> GetAll();
        Parientes Get(String id); 
        bool Add(Parientes model);
        bool Update(Parientes model);
        bool Delete(String id);

    }   
    public class ParientesService : IParientesService
    {
        private readonly ProjectDbContext _projectDbContext;

        public ParientesService(ProjectDbContext projectDbContex)
        {
            _projectDbContext = projectDbContex;
        }


     
        public IEnumerable<Parientes> GetAll()
        {

            var result = new List<Parientes>();

            try
            {
                result = _projectDbContext.Parientes.ToList();
            }
            catch (System.Exception)
            {
              
            }
            return result;
        }


        public Parientes Get(String id)
        {

            var result = new Parientes();

            try
            {
                result = _projectDbContext.Parientes.Single(x => x.Cedula == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }


        public bool Add(Parientes model)
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

        public bool Update(Parientes model)
        {
            try
            {
                var originalModel = _projectDbContext.Parientes.Single(x =>
                x.Cedula == model.Cedula);

                originalModel.Cedula = model.Cedula;
                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
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
                _projectDbContext.Entry(new Parientes { Cedula = id }).State = EntityState.Deleted;
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Parientes Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
