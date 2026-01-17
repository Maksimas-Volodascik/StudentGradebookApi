using System.ComponentModel.DataAnnotations;

namespace StudentGradebookApi.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset EnrollmentDate { get; set; } = DateTimeOffset.Now;
        public string Status { get; set; } = "Enrolled";
        public List<Enrollments> Enrollments { get; set; } = new();  //student can enroll in many classes
        public int UserID { get; set; } //FK
        public WebUsers User { get; set; } = null!;

    }
}
