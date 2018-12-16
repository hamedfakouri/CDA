using Framework.Domain;

namespace CarDamageAssessment.ApplicationCore.Entities
{
    public class Corporate : EntityBase<int>
    {

        
        public string Name { get; set; }

        public string MobileNumber { get; set; }
        
        public User Owner { get; set; }

        public long OwnerId { get; set; }





    }
}
