using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registrar.Data;
using Registrar.Models;

namespace Registrar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<Registration>>> GetStudentRegistrations(int studentId)
        {
            var registrations = await _context.Registrations
                .Where(r => r.StudentId == studentId)
                .ToListAsync();

            if (!registrations.Any())
            {
                return Ok(new List<Registration>());
            }

            return Ok(registrations);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRegistration = await _context.Registrations
                .FirstOrDefaultAsync(r => r.StudentId == registration.StudentId && r.CourseId == registration.CourseId);

            if (existingRegistration == null)
            {
                _context.Registrations.Add(registration);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Unregister([FromBody] Registration registration)
        {
            var existingRegistration = await _context.Registrations
                .FirstOrDefaultAsync(r => r.StudentId == registration.StudentId && r.CourseId == registration.CourseId);

            if (existingRegistration != null)
            {
                _context.Registrations.Remove(existingRegistration);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
