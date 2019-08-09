using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IEstudianteParienteService
    {
        IEnumerable<EstudiantePariente> GetAll();
        EstudiantePariente Get(int id, String idd);
        bool Add(EstudiantePariente model);
        bool Update(EstudiantePariente model);
        bool Delete(int id, String idd);

    }   
    public class EstudianteParienteService : IEstudianteParienteService
    {
        private readonly ProjectDbContext _projectDbContext;

        public EstudianteParienteService(ProjectDbContext projectDbContex)
        {
            _projectDbContext = projectDbContex;
        }


        
        public IEnumerable<EstudiantePariente> GetAll()
        {

            var result = new List<EstudiantePariente>();

            try
            {
                result = _projectDbContext.EstudianteParientes.ToList();
            }
            catch (System.Exception)
            {
              
            }
            return result;
        }


        public EstudiantePariente Get(int id, String idd)
        {

            var result = new EstudiantePariente();

            try
            {
                result = _projectDbContext.EstudianteParientes.Single(x => x.IdEstudiante == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }


        public bool Add(EstudiantePariente model)
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

        public bool Update(EstudiantePariente model)
        {
            try
            {
                var originalModel = _projectDbContext.EstudianteParientes.Single(x =>
                x.IdEstudiante == model.IdEstudiante && x.IdPariente == model.IdPariente);

                originalModel.IdPariente = model.IdPariente;
                originalModel.IdEstudiante = model.IdEstudiante;
                originalModel.TipoRelacion = model.TipoRelacion;



                _projectDbContext.Update(originalModel);
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }


        public bool Delete(int id, String idd)
        {
            try
            {
                _projectDbContext.Entry(new EstudiantePariente { IdEstudiante = id , IdPariente = idd }).State = EntityState.Deleted; 
                _projectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public EstudiantePariente Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
