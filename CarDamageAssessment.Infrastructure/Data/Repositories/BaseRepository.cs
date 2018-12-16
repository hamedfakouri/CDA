using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Framework.Domain;
using Remotion.Linq.Clauses;

namespace CarDamageAssessment.Infrastructure.Data.Repositories
{


    public class BaseRepository <T,Tkey> :IRepository<T,Tkey> 
       where T :EntityBase <Tkey>
    

    {

        public CarDamageAssessmentContext _carDamageAssessmentContext;
        public BaseRepository(CarDamageAssessmentContext carDamageAssessmentContext)
        {
            _carDamageAssessmentContext = carDamageAssessmentContext;
        }

        public void Add(T entity)
        {
    
            _carDamageAssessmentContext.Set<T>().Add(entity);
    
        }

       

        public void Delete(T entity)
        {
            _carDamageAssessmentContext.Set<T>().Remove(entity);

        }

     

        public T GetById(Tkey id)
        {      
            return _carDamageAssessmentContext.Set<T>().AsQueryable().FirstOrDefault(x=> x.Id.Equals(id));
        }

        public override int GetHashCode()
        {
            return -700300278 + EqualityComparer<CarDamageAssessmentContext>.Default.GetHashCode(_carDamageAssessmentContext);
        }

        public IQueryable<T> ListAll()
        {
            var list = _carDamageAssessmentContext.Set<T>().AsQueryable();
            return list;
        }

        public void Update(T entity)
        {
            _carDamageAssessmentContext.Set<T>().Update(entity);
        }
        
    }


  

}
