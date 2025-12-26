using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string First_name { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Last_name { get; set; } = null!;
        public DateTimeOffset Date_of_birth { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset Enrollment_date { get; set; } = DateTimeOffset.Now;
        public string Status { get; set; } = "Enrolled";
        public List<Enrollments> Enrollments { get; set; } = new();  //student can enroll in many classes
        public WebUsers User { get; set; } = null!;
    }
}
