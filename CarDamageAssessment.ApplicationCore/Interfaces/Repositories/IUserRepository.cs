using CarDamageAssessment.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDamageAssessment.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository :IRepository<User,long>
    {
    }
}
