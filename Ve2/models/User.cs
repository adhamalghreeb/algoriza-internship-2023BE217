using System.Reflection;

namespace Ve2.models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum UserType
    {
        RegularUser,
        Doctor,
        Patient
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender UserGender { get; set; }
        public UserType UserType { get; set; }
        
    }



}


