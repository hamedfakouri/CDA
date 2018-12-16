using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data.Repositories
{
    public class CorporateRepository :BaseRepository<Corporate,int>, ICorporateRepository 
    {
        
        public CorporateRepository(CarDamageAssessmentContext carDamageAssessmentContext):base(carDamageAssessmentContext)
        {
      
        }

    }
}
