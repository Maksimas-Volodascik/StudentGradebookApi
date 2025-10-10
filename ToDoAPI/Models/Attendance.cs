using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Attendance
    {
        [Key]
        public int attendance_id { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; } = null!;
        public int enrollment_id { get; set; }
        public Enrollments enrollments { get; set; } = null!;

    }
}
