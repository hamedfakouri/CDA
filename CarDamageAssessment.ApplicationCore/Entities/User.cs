using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Framework.Domain;

namespace CarDamageAssessment.ApplicationCore.Entities
{
   public class User :EntityBase<long>
    {
      
        public string Email { get; set; }
    }
}
