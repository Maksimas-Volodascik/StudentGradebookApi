using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Enrollments
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Select enrollment status!")]
        public string Status { get; set; }
        public int StudentID { get; set; } //FK
        public Students Student { get; set; } = null!;
        public int ClassID { get; set; } //FK
        public Classes Classes { get; set; } = null!;
        public List<Grades> Grades { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
