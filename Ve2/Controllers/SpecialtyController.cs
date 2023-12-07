using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ve2.Dtos;
using Ve2.model;
using Ve2.models;

namespace Ve2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly dbContext _context;
        public SpecialtyController(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var specialties = await _context.Specialties.ToListAsync();

            return Ok(specialties);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SpecialtyDto dto)
        {

            var specialty = new Specialty
            {
                Name = dto.Name,
            };

            await _context.AddAsync(specialty);
            _context.SaveChanges();

            return Ok(specialty);
        }
    }
}
