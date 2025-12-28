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
        public DbSet<WebUsers> WebUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Student)       // Each enrollment can have only one student
                .WithMany(s => s.Enrollments)        // student can have multiple enrollments
                .HasForeignKey(e => e.StudentID); // FK of the Author ID

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Classes)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClassID);

            modelBuilder.Entity<Enrollments>()
                .HasMany(g => g.Grades)
                .WithOne(e => e.Enrollments)
                .HasForeignKey(e => e.Id);

            modelBuilder.Entity<Classes>()
                .HasOne(c => c.Teachers)
                .WithOne(t => t.Classes)
                .HasForeignKey<Teachers>(t => t.Class_id);

            modelBuilder.Entity<Classes>()
                .HasOne(c => c.Subjects)
                .WithOne(s => s.Classes)
                .HasForeignKey<Subjects>(s => s.Class_id);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.enrollments)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.Enrollment_id);

            modelBuilder.Entity<WebUsers>()
                .HasOne(u => u.Teachers)
                .WithOne(s => s.User)
                .HasForeignKey<Teachers>(s => s.UserID);

            modelBuilder.Entity<WebUsers>()
                .HasOne(u => u.Students)
                .WithOne(s => s.User)
                .HasForeignKey<Students>(s => s.UserID);

        }

    }
}
