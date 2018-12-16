using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data
{
   public class CarDamageAssessmentContextFactory : IDesignTimeDbContextFactory<CarDamageAssessmentContext>
    {
        public CarDamageAssessmentContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

            var builder = new DbContextOptionsBuilder<CarDamageAssessmentContext>();


            builder.UseSqlServer(configuration.GetConnectionString("CarDamageAssessmentConnection"));

            return new CarDamageAssessmentContext(builder.Options);
        }


       
    }
}
