using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Course
  {
    public int Id { get; set; }
    [Required]
    public string Code { get; set; } = string.Empty;
    [Required]
    public string Title { get; set; } = string.Empty;
    public int WeeklyHours { get; set; }
    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
  }
}
