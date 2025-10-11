using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDoAPI.Models;

namespace ToDoAPI.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; } = null!;
        public DbSet<Enrollments> Enrollments{ get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Classes> Classes { get; set; } = null!;
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subjects> Subjects { get; set; } = null!;
        public DbSet<Teachers> Teachers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Student)       // Each enrollment can have only one student
                .WithMany(s => s.enrollments)        // student can have multiple enrollments
                .HasForeignKey(e => e.StudentID); // FK of the Author ID

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Classes)
                .WithMany(c => c.enrollments)
                .HasForeignKey(e => e.ClassID);

            modelBuilder.Entity<Enrollments>()
                .HasMany(g => g.Grades)
                .WithOne(e => e.enrollments)
                .HasForeignKey(e => e.grade_id);

            modelBuilder.Entity<Classes>()
                .HasOne(c => c.teachers)
                .WithOne(t => t.classes)
                .HasForeignKey<Teachers>(t => t.class_id);

            modelBuilder.Entity<Classes>()
                .HasOne(c => c.subjects)
                .WithOne(s => s.classes)
                .HasForeignKey<Subjects>(s => s.class_id);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.enrollments)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.enrollment_id);
        }

    }
}
