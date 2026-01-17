using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public string AcademicYear { get; set; } = null!;
        [Required(ErrorMessage = "Must pick a room!")]
        public int Room {  get; set; }
        public ICollection<ClassSubjects> ClassSubjects { get; set; }
    }
}
