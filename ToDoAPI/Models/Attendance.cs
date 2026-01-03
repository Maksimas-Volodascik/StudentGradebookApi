using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Select attendance status!")]
        public string Status { get; set; } = null!;
        public int EnrollmentId { get; set; }
        public Enrollments Enrollments { get; set; } = null!;

    }
}
