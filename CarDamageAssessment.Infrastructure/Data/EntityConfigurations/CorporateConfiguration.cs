using CarDamageAssessment.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data.EntityConfigure
{
  public class CorporateConfiguration :IEntityTypeConfiguration<Corporate>
    {
     

        public void Configure(EntityTypeBuilder<Corporate> builder)
        {
              builder.Property(x => x.Id)
             .ForSqlServerUseSequenceHiLo("corporate_Hilo")
             .IsRequired();
        }
    }
}
