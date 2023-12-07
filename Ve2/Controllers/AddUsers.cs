using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ve2.Dtos;
using Ve2.models;

namespace Ve2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUsers : ControllerBase
    {
        private readonly dbContext _context;
        public AddUsers(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var user = await _context.Users.ToListAsync();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto dto)
        {
            Gender gender = Gender.Male;
            UserType usertype = UserType.RegularUser;
            if (dto.UserGender.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                gender = Gender.Female;
            }
            if (dto.UserType.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            {
                usertype = UserType.Doctor;
            }
            else if(dto.UserType.Equals("Patient", StringComparison.OrdinalIgnoreCase))
            {
                usertype = UserType.Patient;
            }
            var user = new User
            {
                Name = dto.Name,
                UserGender = gender,
                UserType = usertype,
            };

            await _context.AddAsync(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
