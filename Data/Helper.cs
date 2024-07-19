using Registrar.Models;

namespace Registrar.Data
{
  public static class Helper
  {
    public static List<Course> GetCourses()
    {
      List<Course> courses = new List<Course>();

      courses.Add(new Course { Code = "CST8282", Title = "Introduction to Database Systems", WeeklyHours = 4 });
      courses.Add(new Course { Code = "CST8253", Title = "Web Programming II", WeeklyHours = 2 });
      courses.Add(new Course { Code = "CST8256", Title = "Web Programming Language I", WeeklyHours = 5 });
      courses.Add(new Course { Code = "CST8255", Title = "Web Imaging and Animations", WeeklyHours = 2 });
      courses.Add(new Course { Code = "CST8254", Title = "Network Operating System", WeeklyHours = 1 });
      courses.Add(new Course { Code = "CST2200", Title = "Data Warehouse Design", WeeklyHours = 3 });
      courses.Add(new Course { Code = "CST2240", Title = "Advance Database topics", WeeklyHours = 1 });

      return courses;
    }

    public static List<string> GetStudentTypes()
    {
      return new List<string> { "Full Time", "Part Time", "Coop" };
    }

    public static List<Student> GetStudents()
    {
      return new List<Student>
            {
                new Student { Id = 314486, FirstName = "John", LastName = "Smith", Type = "Full Time" },
                new Student { Id = 268072, FirstName = "Martha", LastName = "Jones", Type = "Part Time" },
                new Student { Id = 791864, FirstName = "Rose", LastName = "Tyler", Type = "Coop" }
            };
    }
  }
}
