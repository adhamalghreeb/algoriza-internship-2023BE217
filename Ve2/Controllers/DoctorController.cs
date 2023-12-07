using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ve2.Dtos;

namespace Ve2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly dbContext _context;
        public DoctorController(dbContext context)
        {
            _context = context;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctor = await _context.Doctors.ToListAsync();

            return Ok(doctor);
        }

        [HttpPost("get_by_id")]
        public async Task<IActionResult> GetByIdAsync([FromBody] int doctorId)
        {
            if (doctorId <= 0)
            {
                return BadRequest("Invalid doctor ID");
            }

            var doctor = await _context.Doctors.FindAsync(doctorId);

            if (doctor == null)
            {
                return NotFound("Doctor not found");
            }

            return Ok(doctor);
        }

        [HttpPost("add_doctor")]
        public async Task<IActionResult> CreateAsync(CreateDoctorDto dto)
        {
            Gender gender = Gender.Male;
            if (dto.UserGender.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                gender = Gender.Female;
            }

            var specialty = await _context.Specialties.FirstOrDefaultAsync(s => s.Name == dto.Specialty);
            if (specialty == null)
            {
                specialty = new Specialty { Name = dto.Specialty };
                await _context.Specialties.AddAsync(specialty);
                await _context.SaveChangesAsync();
            }

            var doctor = new Doctor
            {
                Name = dto.Name,
                UserType = UserType.Doctor,
                UserGender = gender,
                SpecialtyId = specialty.SpecialtyId
            };

            

            await _context.AddAsync(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody] Doctor updatedDoctor)
        {
            if (id != updatedDoctor.Id)
            {
                return BadRequest("Mismatched IDs");
            }

            var existingDoctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);

            if (existingDoctor == null)
            {
                return NotFound("Doctor not found");
            }

            // Update the properties of the existing doctor with the values from updatedDoctor
            existingDoctor.Name = updatedDoctor.Name;
            

            // Add other properties as needed

            _context.Doctors.Update(existingDoctor);
            await _context.SaveChangesAsync();

            return Ok(existingDoctor);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound("Doctor not found");
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return Ok("Doctor deleted successfully");
        }
    }
}
