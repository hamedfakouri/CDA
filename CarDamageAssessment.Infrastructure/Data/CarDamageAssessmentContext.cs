using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.Infrastructure.Data.EntityConfigurations;
using CarDamageAssessment.Infrastructure.Data.EntityConfigure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data
{
   public class CarDamageAssessmentContext :DbContext
    {
        public DbSet<Corporate> Corporates { set; get; }

        public DbSet<User> Users { get; set; }


        public CarDamageAssessmentContext(DbContextOptions<CarDamageAssessmentContext> dbContextOptions):base(dbContextOptions)
        {
           
           this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CorporateConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
