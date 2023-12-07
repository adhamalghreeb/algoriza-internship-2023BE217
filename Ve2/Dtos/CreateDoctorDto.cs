namespace Ve2.Dtos
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string UserGender { get; set; }
        public string UserType { get; set; } = "Doctor";
    }
}
