namespace Ve2.models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        
        public string Name { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
