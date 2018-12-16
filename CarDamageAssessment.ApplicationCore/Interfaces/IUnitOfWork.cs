using System;
using System.Collections.Generic;
using System.Text;

namespace CarDamageAssessment.ApplicationCore.Interfaces
{
  public  interface IUnitOfWork
    {
        void Begin();
        void Commit();

        void RollBack();
    }
}
