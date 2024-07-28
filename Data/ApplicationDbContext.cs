using Microsoft.EntityFrameworkCore;
using Registrar.Models;

namespace Registrar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Registration>().ToTable("Registration");

            modelBuilder.Entity<Student>()
                .Property(e => e.Type)
                .HasConversion<string>();

            // Define composite key for Registration
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.StudentId, r.CourseId });

            // Configure relationships if necessary
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Registrations)
                .HasForeignKey(r => r.StudentId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Registrations)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
