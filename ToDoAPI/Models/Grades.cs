using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Grades
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 10, ErrorMessage ="Score must be between 1 and 10")]
        public byte Score { get; set; }
        [Required(ErrorMessage = "Select grade type - default, test, exam")]
        public string Grade_type { get; set; } = null!;
        public int Enrollment_id { get; set; }
        public Enrollments Enrollments { get; set; } = null!;
    }
}
