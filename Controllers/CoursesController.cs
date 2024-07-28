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
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ApplicationDbContext context, ILogger<CoursesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync();
                _logger.LogInformation("Retrieved {Count} courses.", courses.Count);
                return courses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting courses.");
                return StatusCode(500, "Internal server error");
            }
        }

        // Other CRUD operations...
    }
}
