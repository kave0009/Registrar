using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registrar.Data;
using Registrar.Models;

namespace Registrar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetStudentCourses(int studentId)
        {
            var courses = await _context.Registrations
                .Where(r => r.StudentId == studentId)
                .Select(r => r.Course)
                .ToListAsync();

            if (!courses.Any())
            {
                return Ok(new List<Course>());
            }

            return Ok(courses);
        }
    }
}
