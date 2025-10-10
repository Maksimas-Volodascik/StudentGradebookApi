using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Grades
    {
        [Key]
        public int grade_id { get; set; }
        [Range(0, 10, ErrorMessage ="Score must be between 1 and 10")]
        public byte Score { get; set; }
        [Required(ErrorMessage = "Select grade type - default, test, exam")]
        public string grade_type { get; set; } = null!;
        public int enrollment_id { get; set; }
        public Enrollments enrollments { get; set; } = null!;
    }
}
