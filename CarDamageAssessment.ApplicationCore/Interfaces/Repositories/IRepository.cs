using CarDamageAssessment.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDamageAssessment.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository <T,Tkey>
    {
        T GetById(Tkey id);
        IQueryable<T> ListAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
