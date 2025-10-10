using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Attendance
    {
        [Key]
        public int attendance_id { get; set; }
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Select attendance status!")]
        public string status { get; set; } = null!;
        public int enrollment_id { get; set; }
        public Enrollments enrollments { get; set; } = null!;

    }
}
