using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ve2.Dtos;

namespace Ve2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly dbContext _context;
        public PatientController(dbContext context)
        {
            _context = context;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var patient = await _context.Patients.ToListAsync();

            return Ok(patient);
        }

        [HttpPost("get_by_id")]
        public async Task<IActionResult> GetByIdAsync([FromBody] int PatientId)
        {
            if (PatientId <= 0)
            {
                return BadRequest("Invalid Patient ID");
            }

            var patient = await _context.Patients.FindAsync(PatientId);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            return Ok(patient);
        }
    }
}
