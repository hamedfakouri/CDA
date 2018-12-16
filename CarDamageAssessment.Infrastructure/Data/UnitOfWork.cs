using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private CarDamageAssessmentContext _context;
        public UnitOfWork(CarDamageAssessmentContext context)
        {
            _context = context;
        }
        public void Begin()
        {
          var transaction = _context.Database.BeginTransaction();
          _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll;
           
        }

        public void Commit()
        {        
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
