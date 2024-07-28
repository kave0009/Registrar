namespace Registrar.Models
{
    public class Registration
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
