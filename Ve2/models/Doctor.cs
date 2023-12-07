using System.Text.Json.Serialization;

namespace Ve2.model
{
    public class Doctor : User
    {
        public int SpecialtyId { get; set; }

        public Specialty SpecialtyNavigation { get; set; }
    }
}
    
