using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data.Repositories
{
   public class UserRepository :BaseRepository<User,long>,IUserRepository
    {
        public UserRepository(CarDamageAssessmentContext context):base(context)
        {

        }
    }
}
