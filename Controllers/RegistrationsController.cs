using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            var existingRegistration = _context.Registrations
                .FirstOrDefault(r => r.StudentId == registration.StudentId && r.CourseId == registration.CourseId);

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
            var existingRegistration = _context.Registrations
                .FirstOrDefault(r => r.StudentId == registration.StudentId && r.CourseId == registration.CourseId);

            if (existingRegistration != null)
            {
                _context.Registrations.Remove(existingRegistration);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
