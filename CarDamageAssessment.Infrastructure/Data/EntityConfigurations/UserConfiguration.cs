using CarDamageAssessment.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDamageAssessment.Infrastructure.Data.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
                //.HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None); ;
           
            //.ForSqlServerUseSequenceHiLo("user_Hilo") // it should be identity.none
            
        }
    }
}
