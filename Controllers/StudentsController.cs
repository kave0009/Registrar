using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registrar.Data;
using Registrar.Models;

namespace Registrar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ApplicationDbContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                _logger.LogInformation("Retrieved {Count} students.", students.Count);
                return students;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting students.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Retrieved student with ID {Id}.", id);
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the student with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for Student.");
                    return BadRequest(ModelState);
                }
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Created student with ID {Id}.", student.Id);
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the student.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted student with ID {Id}.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the student with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
